﻿using System;
using UnityEngine;
using System.Collections;

public class StartPosition : MonoBehaviour
{

    // Blau RGB: 51 105 232 Normalisiert: 
    private Color blau = new Color(0.2F, 0.042F, 0.910F);
    //Rot RGB: 213 15 37 Normalisiert: 
    private Color rot = new Color(0.835F, 0.059F, 0.145F);
    // Gelb RGB: 238 178 17 Normalisiert: 
    private Color gelb = new Color(0.933F, 0.698F, 0.066F);
    // Gruen RGB: 0 153 37 Normalisiert: 
    private Color gruen = new Color(0.0F, 0.6F, 0, 145F);

    private GameObject Spielelogik;

    // Use this for initialization
    void Awake()
    {
        Spielelogik = GameObject.FindGameObjectWithTag("Spielelogik");
    }

    // Update is called once per frame
    void Update()
    {
        //nix
    }

    private void OnTriggerEnter(Collider other)
    {
        //		try {
        if (!(other.transform.parent.gameObject.transform.parent.gameObject.tag == "Player"))
        {
            return;
        }
        //		} catch (NullReferenceException ex) {
        //			return;
        //		}

        GameObject spieler = other.transform.parent.gameObject.transform.parent.gameObject;
        GameObject marker = transform.gameObject;

        switch (marker.name)
        {
            case "StartPosition1":
                {
                    spieler.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", blau);
                    spieler.transform.GetChild(0).transform.GetChild(3).GetComponent<Renderer>().material.SetColor("_Color", blau);
                    spieler.transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material.SetColor("_Color", blau);
                    spieler.GetComponent<Spieler>().spielerStartpos = 1; 
                    spieler.GetComponent<Spieler>().spawn = marker.transform.position;
                    break;
                }
            case "StartPosition2":
                {
                    spieler.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", rot);
                    spieler.transform.GetChild(0).transform.GetChild(3).GetComponent<Renderer>().material.SetColor("_Color", rot);
                    spieler.transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material.SetColor("_Color", rot);
			spieler.GetComponent<Spieler>().spielerStartpos = 2;
                    spieler.GetComponent<Spieler>().spawn = marker.transform.position;
                    break;
                }
            case "StartPosition3":
                {
                    spieler.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", gelb);
                    spieler.transform.GetChild(0).transform.GetChild(3).GetComponent<Renderer>().material.SetColor("_Color", gelb);
                    spieler.transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material.SetColor("_Color", gelb);
			spieler.GetComponent<Spieler>().spielerStartpos = 3;
                    spieler.GetComponent<Spieler>().spawn = marker.transform.position;
                    break;
                }
            case "StartPosition4":
                {
                    spieler.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", gruen);
                    spieler.transform.GetChild(0).transform.GetChild(3).GetComponent<Renderer>().material.SetColor("_Color", gruen);
                    spieler.transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material.SetColor("_Color", gruen);
			spieler.GetComponent<Spieler>().spielerStartpos = 4;
                    spieler.GetComponent<Spieler>().spawn = marker.transform.position;
                    //spieler.transform.rotation = new Quaternion(0.0f, -0.7f, 0.0f, 0.7f);
                    break;
                }
            default:
                break;
        }
        /* Nach der obigen Initialisierung, hier den Trigger des Colliders deaktivieren."*/
        (gameObject.GetComponent(typeof(Collider)) as Collider).enabled = false;
        //Destroy (marker.transform.parent.gameObject);

        //Spielelogik.GetComponent<Spielelogik>().SpielerStatusAktualisieren(); //(--) nicht sicher warum von Nöten
    }
}