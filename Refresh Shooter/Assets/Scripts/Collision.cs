using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	// Incase they want to change the health of the space rocks
	public float health = 1;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if (health == 0) 
		{
			Die ();	//if no health die
		}
	}



	void OnTriggerEnter2D()
	{
		health--; 		// lose health on trigger enter
	}

	void Die()
	{
		GameManager.instance.ScoreAdd ();	// Adds score using game manager
		FindObjectOfType<GameManager> ().subtractRock ();	// Removes one rock from the count allowing a new one to spawn
		Destroy (gameObject);	// Destroy the rock
	}
}
