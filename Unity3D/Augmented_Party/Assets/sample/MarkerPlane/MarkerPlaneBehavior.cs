using UnityEngine;
using System;
using System.Collections;
using jp.nyatla.nyartoolkit.cs.markersystem;
using jp.nyatla.nyartoolkit.cs.core;
using NyARUnityUtils;
using System.IO;
/// <summary>
/// このサンプルプログラムは、マーカ表面の画像をテクスチャとして取得します。
/// マーカファイルには、hiroマーカを使用してください。
/// </summary>
public class MarkerPlaneBehavior : MonoBehaviour
{
	private NyARUnityMarkerSystem _ms;
	private NyARUnityWebCam _ss;
	private int mid;//marker id
	private GameObject _bg_panel;
	void Awake()
	{
		//setup unity webcam
		WebCamDevice[] devices= WebCamTexture.devices;

		if (devices.Length <=0){
			Debug.LogError("No Webcam.");
			return;
		}
		WebCamTexture w=new WebCamTexture(320,240,15);
		//Make WebcamTexture wrapped Sensor.
		this._ss=NyARUnityWebCam.createInstance(w);
		//Make configulation by Sensor size.
		NyARMarkerSystemConfig config = new NyARMarkerSystemConfig(this._ss.width,this._ss.height);


		this._ms=new NyARUnityMarkerSystem(config);
		mid=this._ms.addARMarker(
			new StreamReader(new MemoryStream(((TextAsset)Resources.Load("patt_hiro",typeof(TextAsset))).bytes)),
			16,25,80);

		//setup background
		this._bg_panel=GameObject.Find("Plane");
		this._bg_panel.GetComponent<Renderer>().material.mainTexture=w;
		this._ms.setARBackgroundTransform(this._bg_panel.transform);
		
		//setup camera projection
		this._ms.setARCameraProjection(this.GetComponent<Camera>());
		return;
	}	
	// Use this for initialization
	void Start ()
	{
		this._ss.start();
	}
	int c=0;
	// Update is called once per frame
	void Update ()
	{
		//Update marker system by ss
		this._ss.update();
		this._ms.update(this._ss);
		Vector3 mpos=Input.mousePosition;
		mpos=this.GetComponent<Camera>().ScreenToViewportPoint(mpos);
		mpos.x=(mpos.x)*320;
		mpos.y=(1.0f-mpos.y)*240;
		Debug.Log(c+":"+mpos.x+","+mpos.y+","+mpos.z);c++;
		//update Gameobject transform
		if(this._ms.isExistMarker(mid)){
			this._ms.setMarkerTransform(mid,GameObject.Find("MarkerObject").transform);
			//マウス座標の取得
			//平面座標に変換
			Vector3 p=new Vector3();
			this._ms.getMarkerPlanePos(mid,(int)mpos.x,(int)mpos.y,ref p);
			GameObject.Find("Cube").transform.localPosition=p;
			Transform t=GameObject.Find("MarkerObject").transform;
		}else{
			// hide Game object
			GameObject.Find("MarkerObject").transform.localPosition=new Vector3(0,0,-100);
		}
	}
}

