﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class animateBalon : MonoBehaviour {

	private Rigidbody2D rb2d;           
	public float speed = 1.5f;
	private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
	private float groundVerticalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.

	//Awake is called before Start.
	private void Awake()
	{
		//Get and store a reference to the collider2D attached to Ground.
		groundCollider = GetComponent<BoxCollider2D>();
		//Store the size of the collider along the x axis (its length in units).
		groundVerticalLength = groundCollider.size.y;
	}

	// Use this for initialization
	void Start()
	{

		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();

		//Start the object moving.
		rb2d.velocity = new Vector2(0, speed);
	}

	void Update()
	{
		//Check if the difference along the x axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
		if (transform.position.y > groundVerticalLength)
		{
			//If true, this means this object is no longer visible and we can safely move it forward to be re-used.
			RepositionBalon();
		}
	}

	//Moves the object this script is attached to right in order to create our looping background effect.
	private void RepositionBalon()
	{
		//This is how far to the right we will move our background object, in this case, twice its length. This will position it directly to the right of the currently visible background object.
		Vector2 groundOffSet = new Vector2(0, groundVerticalLength * -2f);

		//Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
		transform.position = (Vector2)transform.position + groundOffSet;
	}
}
