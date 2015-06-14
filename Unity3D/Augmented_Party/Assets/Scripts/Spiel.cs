using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Spiel : MonoBehaviour {

	public GameObject PlayerPrefab;

	public System.Object Player;

	public GameObject[] spawnpoints_frei;
	public GameObject[] spawnpoints_belegt;

	// Use this for initialization
	void Start () {
		spawnpoints_frei = GameObject.FindGameObjectsWithTag("spawnpoint");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawneSpieler(Transform vb){
		if(Player == null){
		// Man sollte sich noch ueberlegen wie der Spawnpunkt gewaehlt wird.
		Transform spawnpunkt = vb;
		this.Player = Instantiate(PlayerPrefab, (vb.position), (vb.rotation));
		}
	}

}
