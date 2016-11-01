using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public GameObject targetPrefab;
	[SerializeField] private Text scoreText;
	[SerializeField] private Text lifeText;
	[SerializeField] private Text gameOver;
	[SerializeField] private Text scoreEndText;
	[SerializeField] private Text highScoreText;
	GameObject resetGO;
	private Button reset;
	private int score = 0;
	private int targetCount = 0;
	private int life = 30;

	//
	void Start(){
		resetGO = GameObject.FindGameObjectWithTag ("Reset");
		resetGO.SetActive (false);


	}
	// When there are no more targets we are spawning 4 more 
	void Update () {
		if (targetCount == 0) {
			SpawnTargets ();
		}
	}
	//Generates 4 targets in a random location in the mze
	public void SpawnTargets(){
		while (targetCount < 4) {
			GameObject target = targetPrefab;
			Vector3 position = new Vector3 (Random.Range (-20.0f, 20.0f), 1, Random.Range (-20.0f, 20.0f));
			Quaternion rotation = Random.rotation;
			rotation.z = 0;
			rotation.x = 0;
			Instantiate (target, position, rotation);
			targetCount++;
		}
	}
	//Controls the score and keeps track of how many targets are left
	public void TargetHit(){
		targetCount--;
		score++;
		scoreText.text = "Score: " + score;
	}
	//Displays lives remaining and highscore and cancels movement and shooting after you die
	public void PlayerHit(){
		if (life > 0) {
			life--;
		}
		if (life > 10) {
			lifeText.text = "Life: " + life;
		} else {
			lifeText.text = "Life: " + life + "!";
		}
		if (life <= 0) {
			lifeText.text = "Dead!";
			if (score > PlayerPrefs.GetInt ("High Score")) {
				PlayerPrefs.SetInt ("High Score", score);
			}
			gameOver.text = "GAME OVER!";
			scoreEndText.text = "Final Score: " + score;
			highScoreText.text = "High Score: " + PlayerPrefs.GetInt ("High Score");
			resetGO.SetActive (true);
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			Destroy (player.GetComponent<MouseLook>());
			Destroy (player.GetComponent<FPSInput> ());
			Destroy (Camera.main.GetComponent<MouseLook>());
			Destroy (Camera.main.GetComponent<RayShooter>());
			Cursor.lockState = CursorLockMode.None; 
		}
	}
	//Reloads the scene when you click the restart button
	public void RestartOnClick(){
		SceneManager.LoadScene ("Scene1");
	}
}