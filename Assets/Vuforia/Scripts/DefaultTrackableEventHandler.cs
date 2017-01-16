/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;
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
		private bool trackNow = true;
		private bool firstPress = true;
		public GameObject gameButton;
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

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
			//if (!firstPress) {
				if (newStatus == TrackableBehaviour.Status.DETECTED ||
				            newStatus == TrackableBehaviour.Status.TRACKED ||
				            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
					Debug.Log ("TRACKING FOUND !!!!");
					OnTrackingFound ();
				} else {
					Debug.Log ("TRACKING LOST !!!!");
					OnTrackingLost ();
				}
			//}
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			Time.timeScale = 1f;

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
			Time.timeScale = 0f;
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

		public void switchTrackingMode() {
			if (trackNow) {
				TrackerManager.Instance.GetTracker<ObjectTracker> ().Stop ();
				trackNow = false;
				gameButton.GetComponentInChildren<Text>().text = "Start";
			} else {
				trackNow = true;
				TrackerManager.Instance.GetTracker<ObjectTracker> ().Start();

				gameButton.GetComponentInChildren<Text> ().text = "Stop";
			}
		}

        #endregion // PRIVATE_METHODS
    }
}
