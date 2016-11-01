﻿using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {
	public float maxSpeed;
	public float acceleration;
	public float gravity;
	public float vertSpeed;
	public float jumpSpeed;

	private CharacterController charController;

	void Start() {
		charController = GetComponent<CharacterController>();
	}

	void Update() {
		
		//Jumps if the player presses the jump key
		if (charController.isGrounded) {
			//We want to keep this down, but it causes sticky jumps
			//vertSpeed = 0;
			if (Input.GetButtonDown ("Jump")) {
				vertSpeed = jumpSpeed;
			}
		}

		//Controls speed of the player as well as gravity
		float deltaX = Input.GetAxis ("Horizontal") * 0.7f * acceleration;
		float deltaZ = Input.GetAxis ("Vertical") * acceleration;
		Vector3 movement = new Vector3 (deltaX, vertSpeed, deltaZ);
		movement.x = Mathf.Clamp (movement.x, deltaX, deltaX);
		movement.z = Mathf.Clamp (movement.z, deltaZ, deltaZ);
//		movement = deltaX.ClampMagnitude(movement, acceleration);
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		charController.Move (movement);
		if (acceleration < maxSpeed) {
			acceleration += .2f;
		}

		//Skate-like movement, slows player if they try to switch directions quickly
		if (Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0 && acceleration > .6f) {
			acceleration -= 5f;
		}

		//Causes "gravity" when jumping
		if(!charController.isGrounded){
			if (vertSpeed > -26f) {
				vertSpeed += gravity;
			} 
		}
	}
}