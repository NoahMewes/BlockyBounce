using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class DeathController : MonoBehaviour {

	public bool isDead;
	public DeathMenu deathMenu;
	public PauseScript pauseScript;
	public HideScoreScript scoreScript;


	// Use this for initialization
	void Start () {
		gameObject.SetActive (true);
		isDead = false;
	//	Debug.Log (isDead);
	}
	
	// Update is called once per frame
	void Update () {
		//if(GameObject.FindGameObjectWithTag("Player")==null){
		//	isDead = true;
		//	Debug.Log ("Dead");
		//}
		//if (isDead) {
		//	if(GUI.Button(new Rect(50,50,50,50), "Dead")){
			//	EditorSceneManager.LoadScene ("Ball");
			//
		}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Obstacle") {
			gameObject.SetActive (false);
			isDead = true;

			deathMenu.ToggleEndMenu ();
			pauseScript.buttonToggleOff ();
			scoreScript.TurnScoreOff ();
		}

}

	}