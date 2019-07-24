using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class DeathMenu : MonoBehaviour {
	/*(public bool dead;
	DeathController deathController;
	//public GameObject menuPrefab;

	void Start(){
		GameObject Player = GameObject.Find ("Player");
		deathController = Player.GetComponent<DeathController> ();
		gameObject.SetActive (false);
	
	}
	void OnGUI(){
		dead = deathController.isDead;
		//Debug.Log ("OnGUI Called");
		if (dead) {
			Debug.Log ("OnGUI");
			gameObject.SetActive (true);
		}
}*/
	void Start(){
		gameObject.SetActive (false);
	}
	void Update(){
		
	}
	public void ToggleEndMenu(){
		gameObject.SetActive (true);
	}
}
