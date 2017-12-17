using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCleanup : MonoBehaviour {

	public float duration = 5;	// So your shot times out
	float timer = 0;			// A reset for the duration


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += 1 * Time.deltaTime;	// Keep track of timer
		if (timer >= duration) 			// If timer is up destroy shot
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D()				// If it connects destroy the shot
	{
		Destroy (gameObject);
	}
}
