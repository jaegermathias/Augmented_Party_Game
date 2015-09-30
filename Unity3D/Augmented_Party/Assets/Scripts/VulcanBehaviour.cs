using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class VulcanBehaviour : NetworkBehaviour 
{


	#region PUBLIC_MEMBER_VARIABLES
	// Der Lavaklumpen, der gespawned werden soll1
	public GameObject KugelPrefab;
	// Lebensdauer und Intervall von Schuessen
	public int intervall = 10;
	#endregion // PUBLIC_MEMBER_VARIABLES		
	
	#region PRIVATE_MEMBER_VARIABLES
	// Sicherstellen, ob der Vulkan ueberhaupt im Spiel ist
	public bool erkannt = false;
	// Zeitpunkt des letzten Schuss
	[SyncVar]
	private float letzterSchuss = 0.0f;
	// Zielposition
	private Vector3 ziel = new Vector3 (0, 10, 0);
	// Position fuer den Ursprung des Geschoss
	private Vector3 spawnPosition;
	private Vector3 richtungsVektor;
	private Quaternion spawnRotation;
	private Quaternion richtungZentrum;
	#endregion // PRIVATE_MEMBER_VARIABLES


	// Use this for initialization
	void Start ()
	{
		// Vulkanspezifische Initialisierung
		this.spawnPosition = this.GetComponentInChildren<Transform> ().position;
		this.spawnRotation = this.GetComponentInChildren<Transform> ().rotation;
		this.richtungsVektor = new Vector3 (0, 10, 0) - this.spawnPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Positionierung einschraenken.
		Vector3 aktuellePosition = this.GetComponent<Transform> ().position;
		Vector3 eingeschraenktePosition = new Vector3 (aktuellePosition.x, 7.5f, aktuellePosition.z);
		this.GetComponent<Transform> ().position = eingeschraenktePosition;
		//this.transform.position.y = 0;
		
		// Zeit bis zum naechsten Schuss pruefen
		if( Time.time > (letzterSchuss + intervall) && erkannt){ // erkannt muss vom Parent (Target gesetzt werden)
		//if (Time.time > (letzterSchuss + intervall)) {
			// Geroell abfeuern
			feuer ();
			// Abschusszeit festhalten
			letzterSchuss = Time.time;
		}
	}

	void feuer ()
	{
		this.spawnPosition = this.transform.GetChild (0).transform.position;
		this.richtungsVektor = ziel - this.spawnPosition;
		this.spawnRotation = Quaternion.RotateTowards (this.spawnRotation, Quaternion.identity, 360);
		GameObject geroell = (GameObject)Instantiate (KugelPrefab, spawnPosition, this.spawnRotation);
		geroell.GetComponent<Rigidbody> ().velocity = this.richtungsVektor;
		NetworkServer.Spawn(geroell);
		Destroy (geroell, intervall);
	}
}
