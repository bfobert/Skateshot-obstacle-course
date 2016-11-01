using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	
	[SerializeField] GameObject linkPortal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Player") {
			FPSInput player = collidedWith.GetComponent<FPSInput> ();
			if (player.hasTeleported == false) {
				StartCoroutine (player.CheckTeleport ());
				Vector3 destination = linkPortal.transform.position;
				collidedWith.transform.position = destination;
			}
		}
	}
}
