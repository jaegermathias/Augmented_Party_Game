/*============================================================================== 
 * Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections.Generic;
using Vuforia;

/// <summary>
/// This class implements the IVirtualButtonEventHandler interface and
/// contains the logic to swap materials for the teapot model depending on what 
/// virtual button has been pressed.
/// </summary>
public class VirtualButtonEventHandler : MonoBehaviour,
                                         IVirtualButtonEventHandler
{
    #region PUBLIC_MEMBER_VARIABLES

    #endregion // PUBLIC_MEMBER_VARIABLES



    #region PRIVATE_MEMBER_VARIABLES

    #endregion // PRIVATE_MEMBER_VARIABLES



    #region UNITY_MONOBEHAVIOUR_METHODS

	void Start ()
	{
		// Register with the virtual buttons TrackableBehaviour
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();
		for (int i = 0; i < vbs.Length; ++i) {
			vbs [i].RegisterEventHandler (this);
		}
	}

    #endregion // UNITY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS
    
	/// <summary>
	/// Called when the virtual button has just been pressed:
	/// </summary>
	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb)
	{
		//vb.GetComponent<AudioSource>().Play();
		//Debug.Log("OnButtonPressed::" + vb.VirtualButtonName);

		// Add the material corresponding to this virtual button
		// to the active material list:
		switch (vb.VirtualButtonName) {
		case "Spawn1":
			Debug.Log ("Spawn1");
			break;

		case "Spawn2":
			Debug.Log ("Spawn2");    
			break;

		case "Spawn3":
			Debug.Log ("Spawn3");    
			break;
		case "Spawn4":
			Debug.Log ("Spawn4");    
			break;
		}

		GameObject Spiel = GameObject.FindGameObjectWithTag ("spielsteuerung");
		Spiel.SendMessage ("spawneSpieler", vb.transform);
	}
	/// <summary>
	/// Called when the virtual button has just been released:
	/// </summary>
	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb)
	{

	}

    #endregion // PUBLIC_METHODS
}
