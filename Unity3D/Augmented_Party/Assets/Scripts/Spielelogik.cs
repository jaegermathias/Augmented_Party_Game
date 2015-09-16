using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Spielelogik : NetworkBehaviour
{

    [SyncVar]
    public List<GameObject> SpielerListe;

    public Canvas spielerStatus;

    // Blau RGB: 51 105 232 Normalisiert: 
    private static Color blau = new Color(0.2F, 0.042F, 0.910F);
    //Rot RGB: 213 15 37 Normalisiert: 
    private static Color rot = new Color(0.835F, 0.059F, 0.145F);
    // Gelb RGB: 238 178 17 Normalisiert: 
    private static Color gelb = new Color(0.933F, 0.698F, 0.066F);
    // Gruen RGB: 0 153 37 Normalisiert: 
    private static Color gruen = new Color(0.0F, 0.6F, 0, 145F);
    private Color[] farben = new Color[4] { blau, rot, gelb, gruen };

    private GameObject[] spielerTags;

    void Start()
    {
        SpielerListe = new List<GameObject>();
        spielerTags = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in spielerTags)
        {
            SpielerListe.Add(p);
        }
        SpielerStatusAktualisieren();
    }

    void OnPlayerConnected()
    {
        SpielerListe.Clear();
        spielerTags = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in spielerTags)
        {
            SpielerListe.Add(p);
            // Abfragen ob die Leiste fuer die Spieler-Leben vorhanden
            if (this.spielerStatus.GetComponent<SpielerStatus>())
            {
                SpielerStatusAktualisieren();
            }
        }
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        SpielerListe.Clear();
        spielerTags = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in spielerTags)
        {
            SpielerListe.Add(p);
            // Abfragen ob die Leiste fuer die Spieler-Leben vorhanden
            if (this.spielerStatus.GetComponent<SpielerStatus>())
            {
                SpielerStatusAktualisieren();
            }
        }
    }

    public void SpielerStatusAktualisieren()
    {
        Debug.Log("SpielerStatusAktualisieren");
        int i = 0;
        foreach (GameObject SpielerObjekt in SpielerListe)
        {

            // Anzahl der Leben des entsprechenden Spielers abfragen
            int anzahlLeben = SpielerObjekt.GetComponent<Spieler>().leben;
            Debug.Log("Anzahl Leben : " + anzahlLeben);

            // Anzahl Leben in die entsprechende Anzeige einfuegen
            GameObject lebensAnzeige = this.GetComponent<SpielerStatus>().SpielerStatusSammlung[i];
            lebensAnzeige.SetActive(true);
            lebensAnzeige.GetComponent<Text>().text = "";
            lebensAnzeige.GetComponent<Text>().text = anzahlLeben.ToString();
            ////Anzeige mit strichen anstelle der Zahl (geht max bis 3)
            //for (int j = 0; j < anzahlLeben; j++)
            //{
            //    lebensAnzeige.GetComponent<Text>().text += "I";
            //}

            lebensAnzeige.GetComponent<Text>().color = farben[i];
            i++;
            //			SpielerListe.Add(p);
            //			SpielerStatusAktualisieren();
        }

        //GUI.Box(Rect(Screen.width*0.5,Screen.height*0.5,100,25), score.ToString());
        //GUI.Box(Rect(Screen.width*0.5,Screen.height*0.5,100,25), "blllaaaaaa");
    }

    public void SpielerStatusAktualisieren(GameObject GO)
    {
        //StartPosition des Spielers
        int i = GO.GetComponent<Spieler>().StartPos;


        // Anzahl der Leben des entsprechenden Spielers abfragen
        int anzahlLeben = GO.GetComponent<Spieler>().leben;

        Debug.Log("SpielerStatusAktualisieren mit go: " + GO.GetComponent<Spieler>().spielerID +
            " leben:" + anzahlLeben + " Spieler Pos: " + i);
        // Anzahl Leben in die entsprechende Anzeige einfuegen
        GameObject lebensAnzeige = this.GetComponent<SpielerStatus>().SpielerStatusSammlung[i];
        lebensAnzeige.SetActive(true);
        lebensAnzeige.GetComponent<Text>().text = "";
        lebensAnzeige.GetComponent<Text>().text = anzahlLeben.ToString();
        ////Anzeige mit strichen anstelle der Zahl (geht max bis 3)
        //for (int j = 0; j < anzahlLeben; j++) 
        //    {
        //        lebensAnzeige.GetComponent<Text>().text += "I";
        //    }

        lebensAnzeige.GetComponent<Text>().color = farben[i];
        //i++;
        //			SpielerListe.Add(p);
        //			SpielerStatusAktualisieren();
    }

    //GUI.Box(Rect(Screen.width*0.5,Screen.height*0.5,100,25), score.ToString());
    //GUI.Box(Rect(Screen.width*0.5,Screen.height*0.5,100,25), "blllaaaaaa");
}

