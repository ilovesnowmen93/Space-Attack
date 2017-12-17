using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMover : MonoBehaviour {

	public float speed = 100;			// Move speed
	public float rotationSpeed = 300;	// Turn speed
	Rigidbody2D rb;						// For grabbing the rigid body


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent <Rigidbody2D> ();	// Get that rigidbody2D
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow))	// Rotate left
		{
			transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.RightArrow))	// Rotate Right
		{
			transform.Rotate (0, 0, -1 * rotationSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.UpArrow)) 	// Add force forward
		{
			rb.AddForce (transform.up * Time.deltaTime * speed);
		}

		if (Input.GetKey (KeyCode.DownArrow)) 	// Remove force
		{
			rb.AddForce (transform.up * -1 * Time.deltaTime * speed);
		}
	}
}
