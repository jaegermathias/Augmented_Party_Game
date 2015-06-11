using UnityEngine;
using System.Collections;

public class Map_Scale : MonoBehaviour
{
    // Use this for initialization
    public GameObject Target;                                                                   // wird im Editor auf das Marker GO verlinkt
    public float xFaktor, zFaktor;                                                              // Skalierungsfaktoren editierbar im Editor Fenster (Live)

    void Start()
    {
        xFaktor = 5;
        zFaktor = 5;
        /*
        var skript = GetComponent<DefaultTrackableEventHandler>();
        Debug.Log("Pos  " + skript.getPosition());
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Marker Pos X: " + Target.transform.position.x + " Z: " + Target.transform.position.z);  // Consolenausgabe: Position Marker 
        //Debug.Log("Plane  Pos X: " + transform.position.x + " Z: " + transform.position.z);           // Consolenausgabe: Position Plane
        //Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        //Debug.Log("Test Pos über skript: " + Target.DefaultTrackableEventHandler.Pos);
        var tx = Target.transform.position.x;
        //var ty = Target.transform.position.y;                                                 // Höhe wird nicht benötigt
        var tz = Target.transform.position.z;

        transform.localScale = new Vector3((tx / xFaktor), 1, (tz / zFaktor));                   //ändern des Plane Scale anhand der Marker Position/ durch einen Faktor
    }
}
