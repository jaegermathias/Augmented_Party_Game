using UnityEngine;
using System.Collections;

public class vulcan : MonoBehaviour {

	private float letzterSchuss = 0.0f;
	private int lebensdauerGeroell = 2;
	private Vector3 ursprung = new Vector3(0, 10, 0);
	private Vector3 spawnPosition;
	private Vector3 richtungsVektor;
	private Quaternion spawnRotation;
	private Quaternion richtungZentrum;
	// Der Lavaklumpen, der gespawned werden soll
	public GameObject KugelPrefab;

	// Use this for initialization
	void Start () {

		this.spawnPosition = this.GetComponentInChildren<Transform>().position;
		this.spawnRotation = this.GetComponentInChildren<Transform>().rotation;
		this.richtungsVektor = new Vector3 (0, 10, 0) - this.spawnPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if( Time.time > (letzterSchuss + 1.0f))
		   {
			Debug.Log ("Feuer!");
			feuer();
			letzterSchuss = Time.time;
		}
	}

	void feuer(){
		this.spawnPosition = this.transform.GetChild (0).transform.position;
		this.richtungsVektor = new Vector3 (0, 10, 0) - this.spawnPosition;
		this.spawnRotation = Quaternion.RotateTowards(this.spawnRotation, Quaternion.identity, 360);
		GameObject geroell = (GameObject)Instantiate(KugelPrefab, spawnPosition, this.spawnRotation);
		geroell.GetComponent<Rigidbody>().velocity = this.richtungsVektor;
		Destroy (geroell, lebensdauerGeroell);
	
	}
}