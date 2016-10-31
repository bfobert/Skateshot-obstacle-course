using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

	public GameObject bulletPrefab;
	private Camera camera;

	void Start () {
		camera = GetComponent<Camera> ();
		Cursor.lockState = CursorLockMode.Locked; 
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 origin = new Vector3 (camera.pixelWidth / 2,
				camera.pixelHeight / 2,
				0);
			Ray ray = camera.ScreenPointToRay (origin);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				StartCoroutine (Shoot (hit.point));    
			}
		}
	}

	private IEnumerator Shoot(Vector3 position){
		GameObject bullet = Instantiate (bulletPrefab) as GameObject;
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
		yield return new WaitForSeconds (5);
		Destroy (bullet);
	} 

}
