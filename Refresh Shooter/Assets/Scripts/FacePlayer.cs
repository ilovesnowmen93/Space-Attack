using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {


	Transform player;	// Have an empty transform and name it player
	int check;			// Check is used for destroying all rocks when player dies
	int gate = 0;		// Can only be accessed if the rock finds a player

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		check = FindObjectOfType<GameManager> ().playerCheck ();	// This checks to see if the player is alive

		if (check == 1) 
		{
			// This finds the object with tag player
			if (player == null) 
			{
				GameObject go = GameObject.FindWithTag ("Player");
				// sets that object's transform to a variable
				if (go != null)  
				{
					player = go.transform;
					gate = 1;				// Changes gate to 1 allowing it to move towards player
				}
			}
			if (player == null) 
			{
				return;
			}
		} 
		else 
		{
			FindObjectOfType<GameManager> ().subtractRock ();	//If no player subtract a rock
			Destroy (gameObject);								//And destroy gameObject
		}

		if (gate == 1) {
			// This makes the Rock face the player.
			Vector3 direction = player.position - transform.position;	// Get the player's Vector3
			direction.Normalize ();										// This is magic to me sadly

			float zAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90;	// Get the angle of rotation

			transform.rotation = Quaternion.Euler (0, 0, zAngle);						// Rotate to that direction
		}
	}

}
