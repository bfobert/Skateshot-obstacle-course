using UnityEngine;
using System.Collections;

public class TurretBullet : MonoBehaviour {
	
	public float movementSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	//Allows the turret to shoot bullets as projectiles
	void Update () {
		Transform posT = transform;
		Vector3 pos = transform.position;
		pos += posT.forward * Time.deltaTime * movementSpeed;
		transform.position = pos;
	}
	//Controls when the turret shots the player
	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Player") {
			GameObject control = GameObject.FindGameObjectWithTag ("Control");
			Controller c = control.GetComponent<Controller> ();
			c.PlayerHit();
		}
		Destroy (this.gameObject);
	}
}
