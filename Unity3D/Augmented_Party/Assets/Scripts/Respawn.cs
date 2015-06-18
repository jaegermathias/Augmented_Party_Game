using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter (Collider other) {
		GameObject car = other.transform.parent.gameObject.transform.parent.gameObject;
		//Spawnpositionen
		Debug.Log ("Spawnpos: " + car.tag);

		//Vector3 blue = other.transform.gameObject;
		Vector3 red;
		Vector3 yellow;
		Vector3 green;
		if (car.GetComponent<ZusaetzlicheCarInfo> ().leben > 0 && other.transform.parent.gameObject.transform.parent.gameObject.tag == "Player") {
			car.transform.position = new Vector3 (5, 0, 0);
			car.transform.rotation = Quaternion.identity;
			car.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			car.GetComponent<ZusaetzlicheCarInfo> ().leben --;
		}
	}

	private void bla(Collider other){
		if (!(other.transform.parent.gameObject.transform.parent.gameObject.tag == "Player")) {
			return;
		} 
		Destroy(other.gameObject);
	}
}
