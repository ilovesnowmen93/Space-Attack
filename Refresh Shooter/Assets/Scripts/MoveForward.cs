using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {


	public float speed = 10;	// The speed of the rocks or shot


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.up * Time.deltaTime * speed;	// Move the rocks or shot forward
	}
}
