using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {
	public Text countText; 
	public Text FinalText; 
	public int score;
	public int highscore;
	public Text highscoreText;


	void Start () {
		score = 0;
		highscore = PlayerPrefs.GetInt ("highscore", highscore);

	}

	void Update(){
		countText.text = score.ToString ();
		FinalText.text = score.ToString ();
        highscoreText.text = highscore.ToString();
        if (score > highscore){
			Debug.Log ("Huhhhh");
			highscore = score;
			highscoreText.text = highscore.ToString ();

			PlayerPrefs.SetInt ("highscore", highscore);
			PlayerPrefs.Save ();
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Hitbox"){
			score++;
		}
}

}