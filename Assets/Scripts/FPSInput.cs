﻿using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {
	public float speed = 25.0f;
	public float gravity = -9.8f;

	private CharacterController charController;

	void Start() {
		charController = GetComponent<CharacterController>();
	}
	//Controls speed of the player as well as gravity
	void Update() {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);
		movement.y = gravity;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);
	}
}
