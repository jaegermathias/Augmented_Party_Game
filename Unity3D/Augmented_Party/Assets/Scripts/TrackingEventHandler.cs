using UnityEngine;

namespace Vuforia
{
    /// A custom EventHandler der das ITrackableEventHandler interface implementiert.
    public class TrackingEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {

		//public GameObject[] SpieleLogik;
		
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
		public GameObject[] trackingLostComponents;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
		}

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS
  		// ITrackableEventHandler function wenn der State sich aendert
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
			
			Debug.Log("Marker " + mTrackableBehaviour.TrackableName + " gefunden.");

			//trackingLostComponents = GameObject.FindGameObjectsWithTag("TrackingLost");
			// Deaktive TrackingLost-Meldung
			foreach(GameObject t in trackingLostComponents) {
				t.SetActive(false);
			}
		}


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
				//Debug.Log(SpieleLogik[2].SetActive);
                component.enabled = false;
				//GameObject.FindGameObjectsWithTag("Spielelogik")[1].SetActive(true);
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Marker " + mTrackableBehaviour.TrackableName + " verloren.");

			// Aktiviere TrackingLost-Meldung
			foreach(GameObject t in trackingLostComponents) {
				t.SetActive(true);
			}
		}

        #endregion // PRIVATE_METHODS
    }
}
