
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AppAdvisory.social;
#if UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

public class ReloadScene : MonoBehaviour
{
	void Awake()
	{
		GetComponent<Button>().onClick.AddListener(OnClicked);
	}

	void OnClicked()
	{
		#if UNITY_5_3_OR_NEWER
		SceneManager.LoadScene(0);
		#else
		Application.LoadLevel(Application.loadedLevel);
		#endif
	}
}
