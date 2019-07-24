using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScoreScript : MonoBehaviour {

	public bool showScore;

	// Use this for initialization
	void Start () {
		showScore = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (showScore) {
			gameObject.SetActive (true);
		} else {
			Debug.Log ("Halp");
			gameObject.SetActive (false);
		}
	}
	public void TurnScoreOn(){
		showScore = true;
	}
	public void TurnScoreOff(){
		showScore = false;
	}
}
