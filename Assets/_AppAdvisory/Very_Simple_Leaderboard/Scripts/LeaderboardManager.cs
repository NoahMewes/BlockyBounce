
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SocialPlatforms;

#if UNITY_ANDROID && APPADVISORY_LEADERBOARD && VSLEADERBOARD_ENABLE_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#endif

namespace AppAdvisory.social
{
	//using AmazonCommon;
	/// <summary>
	/// Class in charge of the leaderboard.
	/// </summary>
	public static class LeaderboardManager
	{
		public static bool LEADERBOARD_INIT_IS_INITIALIZED = false;
//		#if UNITY_IOS
//		#endif
		public static string LEADERBOARDID
		{
			get
			{
//				return Very_Simple_Leaderboard.GPGSIds.leaderboard_leaderboard;
				return PlayerPrefs.GetString("__LEADERBOARDID");
			}
			set
			{
				Debug.Log("setting leaderboard id = " + value.ToString());
				PlayerPrefs.SetString("__LEADERBOARDID",value);
				PlayerPrefs.Save();
			}
		}



		static ILeaderboard lb;

		/// <summary>
		/// Authenticate and register a ProcessAuthentication callback
		/// This call needs to be made before we can proceed to other calls in the Social API
		/// </summary>
		public static void Init()
		{
			
			#if UNITY_IOS
			try
			{
			Social.localUser.Authenticate (ProcessAuthentication);
			}
			catch(Exception e)
			{
			Debug.Log("------ Authenticate - EXCEPTION : " + e.ToString());
			}
			#endif

			#if UNITY_ANDROID && APPADVISORY_LEADERBOARD && VSLEADERBOARD_ENABLE_ANDROID

//			if(!IsInitialized())
//			{
				// recommended for debugging:
				PlayGamesPlatform.DebugLogEnabled = true;
				// Activate the Google Play Games platform
				PlayGamesPlatform.Activate();

				AuthAndroid();
//			}

			#endif



		}

		public static void AuthAndroid()
		{
			Social.localUser.Authenticate((bool success) => {
				Debug.Log("AuthAndroid success = " + success);
			});
		}

		private static void serviceNotReadyHandler (string error)    {
			Debug.Log("Service is not ready");
		}

		private static void serviceReadyHandler ()    {
			Debug.Log("Service is ready");
		}

		/// <summary>
		/// This function gets called when Authenticate completes
		/// Note that if the operation is successful, Social.localUser will contain data from the server.
		/// </summary>
		public static void ProcessAuthentication (bool success) 
		{
			#if UNITY_IOS && !UNITY_EDITOR
			try
			{
			if (success) 
			{
			try
			{
			Social.LoadScores(LEADERBOARDID, (IScore[] scores) => {

			});
			}
			catch(Exception e)
			{
			Debug.Log("------ LEADERBOARDID - EXCEPTION : " + e.ToString());
			}
			}
			else
			{
			Debug.Log ("Failed to authenticate");
			}
			}
			catch(Exception e)
			{
			Debug.Log("------ ProcessAuthentication - EXCEPTION : " + e.ToString());
			}
			#endif


			#if UNITY_ANDROID
//			PlayGamesPlatform.Instance.LoadScores(
//				LEADERBOARDID,
//				LeaderboardStart.PlayerCentered,
//				100,
//				LeaderboardCollection.Public,
//				LeaderboardTimeSpan.AllTime,
//				(data) =>
//				{
//					string mStatus = "";
//					mStatus = "Leaderboard data valid: " + data.Valid;
//					mStatus += "\n approx:" +data.ApproximateCount + " have " + data.Scores.Length;
//				});
			#endif
		}

		/// <summary>
		/// Call this function to open the leaderboard UI
		/// </summary>
		public static void ShowLeaderboardUI()
		{
			#if UNITY_IOS
			Social.ShowLeaderboardUI();
			#endif

			#if UNITY_ANDROID
			Social.ShowLeaderboardUI();
//			((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (LEADERBOARDID); // Show current (Active) leaderboard
			#endif
		}

		/// <summary>
		/// Call this function to open the achievement UI
		/// </summary>
		public static void ShowAchievementsUI()
		{
			#if UNITY_IOS
			Social.ShowAchievementsUI();
			#endif

			#if UNITY_ANDROID

			if(IsInitialized())
				Social.ShowAchievementsUI();
			else
				AuthAndroid();

			#endif
		}

		/// <summary>
		/// Check if the game service is initialized
		/// </summary>
		public static bool IsInitialized()
		{
			#if UNITY_EDITOR
			return false;
			#else


			#if UNITY_IOS
			return Social.localUser.authenticated;
			#endif

			#if UNITY_AMAZON
			bool isServiceReady = AGSClient.IsServiceReady();
			return isServiceReady;
			#endif

			#if UNITY_ANDROID
			return Social.localUser.authenticated;
			#endif

			return false;

			#endif


		}
		/// <summary>
		/// Report the score to the game service with custom ID (usefull if you have multiple leadrboard)
		/// </summary>
		public static void ReportScore(string leaderboardID,int score)
		{

			#if UNITY_IOS
			if (Social.localUser.authenticated) {		
				try
				{
					if(IsInitialized())
					{
						try
						{
							Social.ReportScore(score,leaderboardID,(bool success) => {
								Debug.Log("succefully post score leaderboard ? " + success);
							});
						}
						catch(Exception e)
						{
							Debug.Log("------ ReportScore - EXCEPTION : " + e.ToString());
						}
					}
				}
				catch(Exception e)
				{
					Debug.Log("------ IsInitialized - EXCEPTION : " + e.ToString());
				}
			}
			else
			{
				Init();
			}
			#endif

			#if UNITY_ANDROID

			if (IsInitialized())
			{
			Social.Active.ReportScore (score, leaderboardID, (bool success) =>
			{
			if (success) {
			Debug.Log ("Update Score Success");

			} else {
			Debug.Log ("Update Score Fail");
			}
			});

			}
			else
			{
			AuthAndroid();
			}
			#endif
		}

		/// <summary>
		/// Report the score to the game service
		/// </summary>
		public static void ReportScore(int score)
		{

			#if UNITY_IOS
			if (Social.localUser.authenticated) {		
			try
			{
			if(IsInitialized())
			{
			try
			{
			Social.ReportScore(score,LEADERBOARDID,(bool success) => {
			Debug.Log("succefully post score leaderboard ? " + success);
			});
			}
			catch(Exception e)
			{
			Debug.Log("------ ReportScore - EXCEPTION : " + e.ToString());
			}
			}
			}
			catch(Exception e)
			{
			Debug.Log("------ IsInitialized - EXCEPTION : " + e.ToString());
			}
			}
			else
			{
			Init();
			}
			#endif

			#if UNITY_ANDROID
		
			if (IsInitialized())
			{
				Social.Active.ReportScore (score, LEADERBOARDID, (bool success) =>
					{
						if (success) {
							Debug.Log ("Update Score Success");

						} else {
							Debug.Log ("Update Score Fail");
						}
					});
			
			}
			else
			{
				AuthAndroid();
			}
			#endif



		}

	}
}