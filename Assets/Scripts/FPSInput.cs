using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {
	public float maxSpeed = 22.0f;
	public float acceleration = 0f;
	public float gravity = -9.8f;
	public float vertSpeed = 0f;
	public float jumpSpeed = 200f;

	private CharacterController charController;

	void Start() {
		charController = GetComponent<CharacterController>();
	}
	//Controls speed of the player as well as gravity
	void Update() {
		if (charController.isGrounded) {
			gravity = -9.8f;
			if (Input.GetButtonDown ("Jump")) {
				vertSpeed = jumpSpeed;
			}
		}
		float deltaX = Input.GetAxis("Horizontal") * acceleration;
		float deltaZ = Input.GetAxis("Vertical") * acceleration;
		Vector3 movement = new Vector3(deltaX, vertSpeed, deltaZ);
		movement = Vector3.ClampMagnitude(movement, acceleration);
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);
		if (acceleration < maxSpeed  && acceleration != 0) {
			acceleration += .2f;
		}
		if (Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0 && acceleration > 0) {
			acceleration -= .6f;
		}
		if (vertSpeed > -10f) {
			vertSpeed += gravity;
			gravity = gravity * .925f;
		}
	}
}
