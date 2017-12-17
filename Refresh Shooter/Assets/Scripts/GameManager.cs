using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
	// This is all player stuff
	public GameObject player; int alive = 0; public int lives = 3;

	// For spawning in the life sprite with the player and keeping track of its loctaion to the player
	public GameObject one; public GameObject two; public GameObject three; public GameObject hrtSpt;

	// Keep track of number of rocks and stuff for random lacation spawn
	public int totalRocks = 3; int rockCount = 0; int rockReset = 0;
	public GameObject rock; Vector3 center = new Vector3 (0,0,0);

	// player score is kept here
	public int Score = 0; public Text scoreText;

	// Keeps track of difficulty level
	public int lvlCounter = 0;

	//Lets manage the game manager
	public static GameManager instance;
	public void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		rockReset = totalRocks;				// Keep a variable for what even the max rocks is set to
		scoreText.text = "Score: " + Score;	// To display the score
	}

	// Update is called once per frame
	void Update () 
	{
		if (lvlCounter >= 5) 	// Counts up to increase the total rock once 5 rocks are destroyed
		{
			totalRocks++;
			lvlCounter = 0;
		}
		if (lives == 0) 
		{
			if (Score >= 1000) 
			{
				SceneManager.LoadScene (2);	// For winning the game
			} 
			else 
			{
				SceneManager.LoadScene (3);	// For losing the game
			}

		}
		if (alive == 0) 
		{
			if(Input.GetKeyDown (KeyCode.Space))	// This manages the players spawning
			{
				if (lives == 3) 
				{
					totalRocks = rockReset;			// Reset the rocks back to the starting amount
					GameObject ship = Instantiate (player, transform.position, transform.rotation);	// Create the player
					GameObject life = Instantiate (three, hrtSpt.transform.position, hrtSpt.transform.rotation); // Create the life marker
					life.transform.parent = ship.transform;	// Attach the life to the player ship
					alive = 1;	// Set player to alive
				} 
				else if (lives == 2)	// This does the same as the previous
				{
					totalRocks = rockReset;
					GameObject ship = Instantiate (player, transform.position, transform.rotation);
					GameObject life = Instantiate (two, hrtSpt.transform.position, hrtSpt.transform.rotation);
					life.transform.parent = ship.transform;
					alive = 1;
				} 
				else if (lives == 1) 	// This does the same as the previous
				{
					totalRocks = rockReset;
					GameObject ship = Instantiate (player, transform.position, transform.rotation);
					GameObject life = Instantiate (one, hrtSpt.transform.position, hrtSpt.transform.rotation);
					life.transform.parent = ship.transform;
					alive = 1;
				}
			}
		}
		if (alive == 1)	// Here we work on the spawning of rocks
		{
			if (totalRocks > rockCount) // Make sure we do not have too many rocks
			{
				Vector3 pos = RandomCircle (center, 15); // Spawn in a random circle
				Instantiate (rock, pos, transform.rotation);
				rockCount++;	// Add a rock to the counter
			}
		}
		scoreText.text = "Score: " + Score; // Display score
		return;	// Just so update does not get stuck
	}
	public void setToDead()	// When player dies set him/her to dead and subtract a life
	{
		alive = 0;
		lives--;
	}

	Vector3 RandomCircle (Vector3 center, float radius) // This is the math for the random circle
	{
		float ang = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin (ang * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos (ang * Mathf.Deg2Rad);
		pos.z = center.z;
		return pos;
	}

	public void subtractRock()	// Used for when a rock is destroyed
	{
		rockCount--;
		lvlCounter++;			// Ticks up the level counter
	}

	public int playerCheck()	// Checks to see if the player is alive or not
	{
		if (alive == 1) 
		{
			return 1;
		} 
		else 
		{
			return 0;
		}
	}
	public void ScoreAdd()		// When a rock is destroyed add 100 points
	{
		Score += 100;

	}
	public int ScoreReturn()	// Return the score number
	{
		return Score;
	}
}
