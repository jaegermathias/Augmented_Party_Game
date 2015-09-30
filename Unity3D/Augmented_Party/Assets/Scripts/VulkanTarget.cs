using UnityEngine;
using System.Collections;


namespace Vuforia
{
	///Vorsicht, noch benoetigt, wenn auch derzeit nicht aktiv
	///Siehe VulcanBehaviour
	public class VulkanTarget : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PUBLIC_MEMBER_VARIABLES
		// Der Lavaklumpen, der gespawned werden soll1
		public bool VulkanErkannt = false;
		public GameObject Vulkan = null;
		#endregion // PUBLIC_MEMBER_VARIABLES		
		
		#region PRIVATE_MEMBER_VARIABLES
		// Vuforia-Trackable-Behaviour
		private TrackableBehaviour mTrackableBehaviour;
		// Sicherstellen, ob der Vulkan ueberhaupt im Spiel ist
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

			Vulkan = this.transform.GetChild (0).gameObject;
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
			// Vulkan aktivieren
			Debug.Log ("Vulkan erkannnt.");
			this.GetComponentInChildren<VulcanBehaviour> ().erkannt = true;
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
			// Vulkan deaktivieren, falls schon initialisiert
			if (Vulkan && Vulkan.GetComponentInChildren<VulcanBehaviour> ()) {
				Debug.Log ("Vulkan verloren.");
				Vulkan.GetComponentInChildren<VulcanBehaviour> ().erkannt = false;
		}
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
		#endregion // PRIVATE_METHODS
	}
}

