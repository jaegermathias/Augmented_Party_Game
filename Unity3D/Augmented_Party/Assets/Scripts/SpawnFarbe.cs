using UnityEngine;
using System.Collections;
using System;

public class SpawnFarbe : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		//nix
	}

	private void OnTriggerEnter (Collider other)
	{
		try {
			if (!(other.transform.parent.gameObject.transform.parent.gameObject.tag == "Player")) {
				return;
			}
		} catch (NullReferenceException ex) {
			return;
		}

		GameObject spieler = other.transform.parent.gameObject.transform.parent.gameObject;
		GameObject marker = transform.gameObject;

		switch (marker.name) {
		case "Spawn_Pos1":
			{
				spieler.transform.GetChild (0).transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.blue;
				spieler.GetComponent<ZusaetzlicheCarInfo> ().farbe = Color.blue; 
				spieler.GetComponent<ZusaetzlicheCarInfo> ().spawn = marker.transform.position;
				spieler.transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, -1.0f);
				Debug.Log ("Case 1, Fahrzeugfarbe:  " + spieler.GetComponent<ZusaetzlicheCarInfo> ().farbe);
				break;
			}
		case "Spawn_Pos2":
			{
				spieler.transform.GetChild (0).transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.red;
				spieler.GetComponent<ZusaetzlicheCarInfo> ().farbe = Color.red;                
				spieler.GetComponent<ZusaetzlicheCarInfo> ().spawn = marker.transform.position;
				spieler.transform.rotation = new Quaternion (0.0f, -0.7f, 0.0f, -0.7f);
				Debug.Log ("Case 2, Fahrzeugfarbe: " + spieler.GetComponent<ZusaetzlicheCarInfo> ().farbe);
				break;
			}
		case "Spawn_Pos3":
			{
				spieler.transform.GetChild (0).transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.yellow;
				spieler.GetComponent<ZusaetzlicheCarInfo> ().farbe = Color.yellow;        
				spieler.GetComponent<ZusaetzlicheCarInfo> ().spawn = marker.transform.position;
				spieler.transform.rotation = new Quaternion (0.0f, 1.0f, 0.0f, 0.0f);
				Debug.Log ("Case 3, Fahrzeugfarbe: " + spieler.GetComponent<ZusaetzlicheCarInfo> ().farbe);
				break;
			}
		case "Spawn_Pos4":
			{
				spieler.transform.GetChild (0).transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.green;
				spieler.GetComponent<ZusaetzlicheCarInfo> ().farbe = Color.green;        
				spieler.GetComponent<ZusaetzlicheCarInfo> ().spawn = marker.transform.position;
				spieler.transform.rotation = new Quaternion (0.0f, -0.7f, 0.0f, 0.7f);
				Debug.Log ("Case 4, Fahrzeugfarbe: " + spieler.GetComponent<ZusaetzlicheCarInfo> ().farbe);
				break;
			}
		default:
			break;
		}
		Debug.Log (marker.transform.parent.gameObject);
		Destroy (marker.transform.parent.gameObject);
	}
}
