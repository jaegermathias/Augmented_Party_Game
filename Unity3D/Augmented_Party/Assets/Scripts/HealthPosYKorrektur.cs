using UnityEngine;
using System.Collections;

public class HealthPosYKorrektur : MonoBehaviour
{
    public float hoehePowerup;

    // Use this for initialization
    void Start()
    {
        hoehePowerup = 12.5f;
    }

    // Update is called once per frame
    void Update()
    {
        #region Fixierung der Y-Achse
        //Fixierung der Y-Achse auf eine Bestimmte höhe sodass das Powerup immer auf der Plattform ist
        Vector3 aktuellePosition = this.GetComponent<Transform>().position;
        Vector3 eingeschraenktePosition = new Vector3(aktuellePosition.x, hoehePowerup, aktuellePosition.z);
        this.GetComponent<Transform>().position = eingeschraenktePosition;
        #endregion
    }
}
