using UnityEngine;
using System.Collections;


namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class vulcan : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PUBLIC_MEMBER_VARIABLES
		// Der Lavaklumpen, der gespawned werden soll
		public GameObject KugelPrefab;
		// Lebensdauer und Intervall von Schuessen
		public int intervall = 10;
		#endregion // PUBLIC_MEMBER_VARIABLES		
		
		#region PRIVATE_MEMBER_VARIABLES
		private TrackableBehaviour mTrackableBehaviour;
		private float letzterSchuss = 0.0f;
		private Vector3 ursprung = new Vector3(0, 10, 0);
		private Vector3 spawnPosition;
		private Vector3 richtungsVektor;
		private Quaternion spawnRotation;
		private Quaternion richtungZentrum;
		#endregion // PRIVATE_MEMBER_VARIABLES
		
		
		
		#region UNTIY_MONOBEHAVIOUR_METHODS
		
		void Start()
		{
			// Markerspezifische Initialisierung
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}

			// Vulkanspezifische Initialisierung
			this.spawnPosition = this.GetComponentInChildren<Transform>().position;
			this.spawnRotation = this.GetComponentInChildren<Transform>().rotation;
			this.richtungsVektor = new Vector3 (0, 10, 0) - this.spawnPosition;
		}

		// Update is called once per frame
		void Update () {
			// Positionierung einschraenken.
			Vector3 aktuellePosition = this.GetComponent<Transform> ().position;
			Vector3 eingeschraenktePosition = new Vector3 (aktuellePosition.x, 0, aktuellePosition.z);
			this.GetComponent<Transform> ().position = eingeschraenktePosition;
			//this.transform.position.y = 0;
			
			// Zeit bis zum naechsten Schuss pruefen
			if( Time.time > (letzterSchuss + intervall))
			{
				// Geroell abfeuern
				feuer();
				// Abschusszeit festhalten
				letzterSchuss = Time.time;
			}
		}
		
		#endregion // UNTIY_MONOBEHAVIOUR_METHODS
		
		
		
		#region PUBLIC_METHODS
		
		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
			    newStatus == TrackableBehaviour.Status.TRACKED ||
			    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}
		
		#endregion // PUBLIC_METHODS
		
		
		
		#region PRIVATE_METHODS
		
		
		private void OnTrackingFound()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			
			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}
			
			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}
			
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}
		
		
		private void OnTrackingLost()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			
			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}
			
			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}
			
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}

		// Vulcan-Skript

		// Funktion zum Schiessen
		void feuer(){
			this.spawnPosition = this.transform.GetChild (0).transform.position;
			this.richtungsVektor = new Vector3 (0, 10, 0) - this.spawnPosition;
			this.spawnRotation = Quaternion.RotateTowards(this.spawnRotation, Quaternion.identity, 360);
			GameObject geroell = (GameObject)Instantiate(KugelPrefab, spawnPosition, this.spawnRotation);
			geroell.GetComponent<Rigidbody>().velocity = this.richtungsVektor;
			Destroy (geroell, intervall);
		}
		#endregion // PRIVATE_METHODS
	}
}

