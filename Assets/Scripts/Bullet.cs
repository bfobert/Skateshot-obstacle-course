using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float movementSpeed;

	// Use this for initialization
	void Start () {
	
	}

	// Allows the ball to be shot as a projectile vs teleporting the ball
	void Update () {
		Transform posT = transform;
		Vector3 pos = transform.position;
		pos += posT.forward * Time.deltaTime * movementSpeed;
		transform.position = pos;
	}
	//Controls the collisions 
	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Target") {
			GameObject control = GameObject.FindGameObjectWithTag ("Control");
			Controller c = control.GetComponent<Controller> ();
			c.TargetHit();
			Destroy (collidedWith);
		}
		Destroy (gameObject);
	}
}