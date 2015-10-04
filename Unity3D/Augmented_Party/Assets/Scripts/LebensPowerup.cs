using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LebensPowerup : MonoBehaviour
{
    #region Public Stuff
    public int geschwindigkeit;
    public bool animation;
    public Material matRED;
    public Material matPuple;
    public int intervall;
    public bool erkannt;
    public int rdm;

    #endregion

    #region PrivatScheiß
    private float frequenz;
    private float ausschlag;
    [SyncVar]
    private float letzterSpawn = 0.0f;
    #endregion


    //To-Doo
    /*
     * #DONE -Verschwindet bei Collision
     * #DONE -Taucht nach gewisser Zeit auf 
     * #DONE -Random Red or Purple
     * #DONE -Plus leben/Minus Leben
     * -Netzwerk Sync
     * #DONE -Force Y Höhe
     *          
     */

    void Start()
    {
        geschwindigkeit = 5;
        animation = true;
        erkannt = false;
        intervall = 5;
        disableHealth();
    }

    void Update()
    {

        #region Optische Animation
        if (animation)
        {
            //Rotation Kreuz
            transform.Rotate(0, 0, Time.deltaTime + geschwindigkeit);
            transform.Rotate(0, Time.deltaTime, 0, Space.World);

            //Hover Effekt Kreuz
            frequenz = 0.50f;
            ausschlag = 0.50f;
            transform.position += (ausschlag * (Mathf.Sin(2 * Mathf.PI * frequenz * Time.time) - Mathf.Sin(2 * Mathf.PI * /*Black Magic*/  frequenz * (Time.time - Time.deltaTime))))*Vector3.up;
        }
        #endregion

        #region Spawn
        if (Time.time > (letzterSpawn + intervall) && erkannt)
        { // erkannt muss vom Parent (Target gesetzt werden)
           
            showKreuz();
            // Zeit des letzten Spawns festhalten
            letzterSpawn = Time.time;
        }
        #endregion


    }

    void showKreuz()
    {

        rdm = Random.Range(0, 2);
        Debug.Log("Random Number: " + rdm);

        
        switch (rdm)
        {
            case 0: //Red One
                GetComponent<Renderer>().material = matRED;
                Debug.Log("Rotes Kreuz");
                break;
            case 1: //Puple One
                GetComponent<Renderer>().material = matPuple;
                Debug.Log("Lila Kreuz");
                break;
            default:
                Debug.Log("Random ist Doof!");
                break;
        }
        enableHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject car = other.transform.parent.gameObject.transform.parent.gameObject;
        switch (rdm)
        {
            case 0: //Red One
                car.GetComponent<Spieler>().spielerLebenErhoehen();
               Debug.Log("leben dazu! Jetzt: " + other.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Spieler>().spielerLeben);
               //Objekt kriegt leben dazu
                break;
            case 1: //Puple One
                car.GetComponent<Spieler>().spielerLebenReduzieren();
                Debug.Log("leben weg! Jetzt: " + other.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Spieler>().spielerLeben);
              //Objekt verliert Leben
                break;
            default:
                Debug.Log("Random ist Doof!");
                break;
        }
        disableHealth();
    }

    private void enableHealth()
    {
        this.gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.GetComponent<Collider>().enabled = true;
        Debug.Log("Health ON");
    }

    private void disableHealth()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
        Debug.Log("Health OFF");
    }

}
