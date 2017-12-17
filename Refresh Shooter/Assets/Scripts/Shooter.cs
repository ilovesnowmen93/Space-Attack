using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject shotPrefab;		// Hold the shot



	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) // When space is pressed spawn at shot
		{
			Instantiate (shotPrefab, transform.position, transform.rotation);
		}
	}
}
