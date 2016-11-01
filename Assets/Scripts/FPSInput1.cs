using UnityEngine;
using System.Collections;

public class FPSInput1 : MonoBehaviour {
	public float maxSpeed;
	public float acceleration;
	public float gravity;
	public float vertSpeed;
	public float jumpSpeed;

	private CharacterController charController;

	void Start() {
		charController = GetComponent<CharacterController>();
	}
	//Controls speed of the player as well as gravity
	void Update() {
		if (charController.isGrounded) {
			gravity = -7f;
			if (Input.GetButtonDown ("Jump")) {
				vertSpeed = jumpSpeed;
			} 
		}
		float deltaX = Input.GetAxis("Horizontal") * acceleration;
		float deltaZ = Input.GetAxis("Vertical") * acceleration;
		Vector3 movement = new Vector3(deltaX, vertSpeed, deltaZ);
		movement.x = Mathf.Clamp (movement.x, deltaX, deltaX);
		movement.z = Mathf.Clamp (movement.z, deltaZ, deltaZ);
//		movement = deltaX.ClampMagnitude(movement, acceleration);
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);
		if (acceleration < maxSpeed) {
			acceleration += .2f;
		}

		if (Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0 && acceleration > .6f) {
				acceleration -= .6f;
			
		}
		if (vertSpeed > -36f) {
			vertSpeed += gravity;
			gravity = gravity * 1.02f;
		}

	}
}