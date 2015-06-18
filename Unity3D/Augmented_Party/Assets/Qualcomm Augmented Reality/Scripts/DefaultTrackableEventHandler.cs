/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES

        #region PUBLIC_MEMBER_VARIABLES

        public static Vector3 Pos;
        public Vector3 newPos;
        public Vector3 toleranz;
        public GameObject Spielfeld;

        #endregion // PUBLIC_MEMBER_VARIABLES


        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
            Pos = new Vector3(0, 0, 0);
            toleranz = new Vector3(0, 0, 0);
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

        public Vector3 getPosition
        {
            get { return Pos; }
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

            UpdatePos();
        }
         private void UpdatePos()
        {
            newPos = transform.position;
            //Save Position for PlaneSkript:
            //X
            var xtest = (newPos.x > Pos.x + toleranz.x) || (newPos.x > Pos.x - toleranz.x) || (newPos.x < Pos.x + toleranz.x) || (newPos.x < Pos.x - toleranz.x);
            //Y
            var ytest = (newPos.y > Pos.y + toleranz.y) || (newPos.y > Pos.y - toleranz.y) || (newPos.y < Pos.y + toleranz.y) || (newPos.y < Pos.y - toleranz.y);
            //Z
            var ztest = (newPos.z > Pos.z + toleranz.z) || (newPos.z > Pos.z - toleranz.z) || (newPos.z < Pos.z + toleranz.z) || (newPos.z < Pos.z - toleranz.z);

            if (xtest || ytest || ztest)
            {
                Pos = newPos;
                MarkerBehaviour marker = (MarkerBehaviour)mTrackableBehaviour;
                //Debug.Log("Trackable " + marker.Marker.ID + " found");


                Spielfeld.SendMessage("neuePos", new Vector4(Pos.x, Pos.y, Pos.z, marker.Marker.MarkerID));
                //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
                //Debug.Log(mTrackableBehaviour.TrackableName + " Positioon " + Pos.x + " , " + Pos.z);
            }
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

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

        }

        #endregion // PRIVATE_METHODS
    }
}