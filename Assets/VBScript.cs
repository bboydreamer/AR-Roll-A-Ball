using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBScript : MonoBehaviour, IVirtualButtonEventHandler {

	// Use this for initialization
	public GameObject virtualButtonObject;
	public float speed;

	void Start () 
	{
		virtualButtonObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb) 
	{
		
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb)
	{
		
	}

}
