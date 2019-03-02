using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GooglePlayServices : MonoBehaviour
{

	//ID classifica
	private string leaderboard = "CgkIxojWsPYKEAIQAQ";

	void Start()
	{
		Time.timeScale = 1; //devo mettere il timescale a 1 perchè quando il gioco va in pausa(il player ha perso) il timescale diventa 0, e se si torna nel menu principale...
		//...il timescale rimane a 0(e ad es. le animazioni dei pulsanti non funzionano)
	}

	public void Awake()
	{		
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			
			.Build();
		
		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate(); //attivo la piattaforma

		//autenticazione dell utente che sta entrando nella piattaforma
		Social.localUser.Authenticate((bool success) =>
      	{
			if(success)
			{
				Debug.Log("You've successfully logged in");
			}
			else
			{
				Debug.Log("Login failed for some reason");
			}
		});
	}

	public void ShowScores(int startScore)
	{
		if(startScore == 1)
		{
			if(Social.localUser.authenticated) //se l'utente è già stato autenticato(cioè ha fatto il login alla piattaforma di GooglePlayServices)
			{
				//pubblico il mio punteggio(l' "Highscore" del giocatore) alla classifica
				Social.ReportScore((long)PlayerPrefs.GetFloat("Highscore"), leaderboard, (bool success) =>
				{
					if(success)
					{
						PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboard); //mostra l'UI standard della classifica 
					}
					else
					{
						//Debug.Log("Login failed for some reason");
					}
				});
			}
		}
	}

	public void ShowAchievements(int startAchievements)
	{
		if(startAchievements == 1)
		{
			if(Social.localUser.authenticated) //se l'utente è già stato autenticato(cioè ha fatto il login alla piattaforma di GooglePlayServices)
			{
				Social.ShowAchievementsUI(); //mostra l'UI standard dei risultati
			}
		}
	}

}