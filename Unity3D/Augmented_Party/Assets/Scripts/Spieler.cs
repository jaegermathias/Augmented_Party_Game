﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Spieler : NetworkBehaviour {

	//[SyncVar]
    //public int moveX = 0;
    //public int moveY = 0;
	public int spielerLeben;
    public int spielerStartpos;
    public Vector3 spawn;
    public string spielerID;
	//public float moveSpeed = 0.2f;

	//[SyncVar]
	//public Color myColor;

	void Start()
	{
 		DontDestroyOnLoad(gameObject);
        this.spielerLeben = 4;
        spielerID = this.netId.ToString();
    }

	public void spielerLebenAktualisieren()
	{
		this.spielerLeben--;
		GameObject Spielelogik = GameObject.FindGameObjectWithTag("Spielelogik");
		Spielelogik.GetComponent<Spielelogik>().SpielerStatusAktualisieren();
	}

	public override void OnStartClient()
	{
		//Debug.Log("Player OnStartClient netId:" + netId + " crate:" + this.crate);
		//GetComponent<MeshRenderer>().material.color = myColor;
	}

	public override void OnStartLocalPlayer ()
	{
		base.OnStartLocalPlayer ();
		Debug.Log ("Spieler-Nr.:" + this.netId);
		Debug.Log ("This: " + this + " This.getType(): " + this.GetType());
        spielerID = this.netId.ToString();
	}
		
//	[ClientRpc]
//	void RpcPoke(int value)
//	{
//		Debug.Log("value:"+value);
//	}
//
//
//	[Command]
//	void CmdMakeCrate()
//	{
//
//		GameObject crate = (GameObject)Instantiate(cratePrefab, transform.position, Quaternion.identity);
//		NetworkServer.Spawn(crate);
//
//		this.crate = crate;
//	}

	void Update () 
	{
		if (!isLocalPlayer) {
			return;
		}
		
		// input handling for local player only
//		int oldMoveX = moveX;
//		int oldMoveY = moveY;
//		
//		moveX = 0;
//		moveY = 0;

//		if (Input.GetKeyDown(KeyCode.Space))
//		{
//			CmdMakeCrate();
//		}
//		if (Input.GetKeyDown(KeyCode.Escape))
//		{
//			CmdLobby();
//		}
//		if (Input.GetKey(KeyCode.LeftArrow))
//		{
//			moveX -= 1;
//		}
//		if (Input.GetKey(KeyCode.RightArrow))
//		{
//			moveX += 1;
//		}
//		if (Input.GetKey(KeyCode.UpArrow))
//		{
//			moveY += 1;
//		}
//		if (Input.GetKey(KeyCode.DownArrow))
//		{
//			moveY -= 1;
//		}
//		if (moveX != oldMoveX || moveY != oldMoveY)
//		{
//			CmdMove(moveX, moveY);
//		}
	}
	
//	[Command]
//	public void CmdLobby()
//	{
//		var lobby = NetworkManager.singleton as NetworkLobbyManager;
//		NetworkManager.singleton.ServerChangeScene(lobby.lobbyScene);
//	}
//
//	[Command]
//	public void CmdMove(int x, int y)
//	{
//		moveX = x;
//		moveY = y;
//		transform.Translate(moveX * moveSpeed, moveY * moveSpeed, 0);
//		base.SetDirtyBit(1);
//	}
//	
//	[ServerCallback]
//	public void FixedUpdate()
//	{
//		transform.Translate(moveX * moveSpeed, moveY * moveSpeed, 0);
//	}
}
