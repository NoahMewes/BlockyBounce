using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public bool showPauseButton;

	// Use this for initialization
	void Start () {
		showPauseButton = true;
	}

	// Update is called once per frame
	void Update () {
		if (showPauseButton) {
			gameObject.SetActive (true);
		} 
		else {
			gameObject.SetActive (false);
		}

	}
	public void buttonToggleOff(){
		showPauseButton = false;
	}

	public void buttonToggleOn(){
		showPauseButton = true;
	}


	public void PauseButtonFunction()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
	}
}
