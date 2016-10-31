using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {
	public float maxSpeed = 22.0f;
	public float acceleration = 0f;
	public float gravity = -9.8f;

	private CharacterController charController;

	void Start() {
		charController = GetComponent<CharacterController>();
	}
	//Controls speed of the player as well as gravity
	void Update() {
		float deltaX = Input.GetAxis("Horizontal") * acceleration;
		float deltaZ = Input.GetAxis("Vertical") * acceleration;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, acceleration);
		movement.y = gravity;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);
		if (acceleration < maxSpeed) {
			acceleration += .2f;
		}
		if (Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0) {
			acceleration -= .4f;
		}
	}
}
