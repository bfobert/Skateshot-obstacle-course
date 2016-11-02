using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPSInput : MonoBehaviour {
	public float maxSpeed;
	public float acceleration;
	public float horizSpeed;
	public float gravity;
	public float vertSpeed;
	public float jumpSpeed;
	public bool hasTeleported;

	private CharacterController charController;

	void Start() {
		charController = GetComponent<CharacterController>();
		hasTeleported = false;
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

		acceleration = Mathf.Clamp (acceleration, 0f, 30f);

		//Controls speed of the player as well as gravity
		float deltaX = Input.GetAxis ("Horizontal") * horizSpeed;
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
			acceleration -= 1f;
		}

		//Causes "gravity" when jumping
		if(!charController.isGrounded){
			if (vertSpeed > -26f) {
				vertSpeed += gravity;
			} 
		}
	}
	public IEnumerator CheckTeleport(){
		hasTeleported = true;
		yield return new WaitForSeconds (3);
		hasTeleported = false;
	}
}