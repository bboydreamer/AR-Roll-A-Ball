using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour {

	// Update is called once per frame
	private Rigidbody sphereRB;
	private Transform sphereTransform;
	public float speed;
	private bool upPressed, downPressed, leftPressed, rightPressed = false;

	void Start() 
	{
		sphereRB = GetComponent<Rigidbody> ();
		sphereTransform = GetComponent<Transform> ();
	}


	void Update()
	{
		//Imagine getAxis as getting the position of a joystick in the specified axis

		//sphereTransform.position.y = Mathf.Max (0.0f, sphereTransform.position.y);
		Vector3 moveUp = new Vector3 (0.0f, 0.0f, 1.0f) * speed;
		Vector3 moveDown = new Vector3 (0.0f, 0.0f, -1.0f) * speed;
		Vector3 moveLeft = new Vector3 (-1.0f, 0.0f, 0.0f) * speed;
		Vector3 moveRight = new Vector3 (1.0f, 0.0f, 0.0f) * speed;

		if (upPressed) {
			Debug.Log ("Moving up");
			Debug.Log (moveUp);
			sphereRB.AddForce (moveUp);
		} else if (downPressed) {
			Debug.Log ("Moving down");
			Debug.Log (moveDown);
			sphereRB.AddForce (moveDown);
		} else if (leftPressed) {
			Debug.Log ("Moving left");
			Debug.Log (moveLeft);
			sphereRB.AddForce (moveLeft);
		} else if (rightPressed) {
			Debug.Log ("Moving right");
			Debug.Log (moveRight);
			sphereRB.AddForce (moveRight);
		}
	}

	public void onPointerPress(string direction) {
		if (direction == "up") {
			upPressed = true;
		} else if (direction == "down") {
			downPressed = true;
		} else if (direction == "left") {
			leftPressed = true;
		} else if (direction == "right") {
			rightPressed = true;
		} 
	}
	public void onPointerRelease(string direction) {
		if (direction == "up") {
			upPressed = false;
		} else if (direction == "down") {
			downPressed = false;
		} else if (direction == "left") {
			leftPressed = false;
		} else if (direction == "right") {
			rightPressed = false;
		} 
	}

}
