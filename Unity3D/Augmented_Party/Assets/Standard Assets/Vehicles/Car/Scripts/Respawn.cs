using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	public GameObject car;
	public Vector3 pos;
	int lives;
	void Start () {
		pos = new Vector3 (1, 1, 1);
		lives = 4;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Car Pos y: " + transform.position.y);
		if(transform.position.y < -10f && lives > 0) {
			transform.position = pos;
			lives--;
		}
	}

}
