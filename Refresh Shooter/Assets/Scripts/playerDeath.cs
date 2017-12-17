using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour {


	public int health = 1;	// Keep track of the player's health

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health == 0)	// Kill the player if out of health
		{
			Die ();
		}
	}



	void OnTriggerEnter2D()	// On trigger enter lose life
	{
		health--;
	}

	void Die()
	{
		FindObjectOfType<GameManager> ().setToDead ();	// Set player to dead
		Destroy (gameObject);							// Destroy player
	}
}
