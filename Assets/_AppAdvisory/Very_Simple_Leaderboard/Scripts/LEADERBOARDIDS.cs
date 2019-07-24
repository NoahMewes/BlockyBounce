
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/

#if UNITY_EDITOR
using UnityEditor;
#endif

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
#pragma warning disable 0618 // obslolete
#pragma warning disable 0108 
#pragma warning disable 0162 

using UnityEngine;
using System.Collections;

namespace AppAdvisory.social
{
	public class LEADERBOARDIDS : ScriptableObject
	{
		public bool FIRST_TIME = true;
		public bool ENABLE_IOS = false;
		public bool ENABLE_ANDROID = false;

		public string LEADERBOARDID_IOS = "fr.appadvisory.amazingbrick";
		public string LEADERBOARDID_ANDROID = "fr.appadvisory.amazingbrick";

		public string LEADERBOARDID
		{
			get
			{
				#if UNITY_IOS
				return LEADERBOARDID_IOS;
				#endif

				#if UNITY_ANDROID
				return LEADERBOARDID_ANDROID;
				#endif

				#if !UNITY_IOS && !UNITY_ANDROID
				return "";
				#endif
			}
		}

		public bool isLeaderboardIDsFoldoutOpened = false;


		public void Init()
		{}

		#region EDITOR
		public static readonly string PATH = "Assets/_AppAdvisory/Very_Simple_Leaderboard/";
		public static readonly string NAME = "LEADERBOARD_SETTING";

		private static string PathToAsset 
		{
			get 
			{
				return PATH + NAME + ".asset";
			}
		}

		#if UNITY_EDITOR

		[MenuItem("Assets/Create/AppAdvisory/LeaderboardSettings")]
		public static void CreateLeaderboardettings()
		{
			LEADERBOARDIDS asset = ScriptableObject.CreateInstance<LEADERBOARDIDS>();

			AssetDatabase.CreateAsset(asset, PathToAsset);
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = asset;
		}

		#endif

		#endregion
	}
}