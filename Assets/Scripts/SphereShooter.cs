using UnityEngine;
using System.Collections;


public class SphereShooter : MonoBehaviour {
	
	public GameObject turretBulletPrefab;
	private float rotSpeed = 30f;

	void Start () {
	}
	
	void Update () {
			Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
			RaycastHit hit;
			if(Physics.SphereCast(ray, .75f, out hit)){
				StartCoroutine (Shoot (hit.point));
			}
		transform.Rotate (Vector3.up * Time.deltaTime * rotSpeed);
	}

	private IEnumerator Shoot(Vector3 position){
		GameObject turretBullet = Instantiate (turretBulletPrefab) as GameObject;
		Vector3 pos = transform.position;
		pos.y += .45f;
		turretBullet.transform.position = pos;
		turretBullet.transform.rotation = transform.rotation;
		yield return new WaitForSeconds (5);
		Destroy (turretBullet);
	} 
}