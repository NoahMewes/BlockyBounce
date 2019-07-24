
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetText : MonoBehaviour {

	public string iOSText = "Open Leaderboard";
	public string AndroidText = "Open Leaderboard";

	void Awake()
	{
		#if UNITY_IOS
		GetComponent<Text>().text = iOSText;
		#elif UNITY_ANDROID
		GetComponent<Text>().text = AndroidText;
		#else
		GetComponent<Text>().text = "PLEASE CHANGE YOUR PLATFORM FOR iOS OR ANDROID";
		#endif
	}
}
