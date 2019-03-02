using UnityEngine;
using System.Collections;

public class AchievementsSystem : MonoBehaviour {

	public float scoreGame;
	public bool fireIsUsed;
	public bool shieldIsUded;

	//ID risultati
	private string SWALLOW = "CgkIxojWsPYKEAIQAg";
	private string SPARROW = "CgkIxojWsPYKEAIQAw";
	private string HUMMINGBIRD = "CgkIxojWsPYKEAIQBA";
	private string PIGEON = "CgkIxojWsPYKEAIQBQ";
	private string PHEASANT = "CgkIxojWsPYKEAIQBg";
	private string CRANE = "CgkIxojWsPYKEAIQBw";
	private string QUAIL = "CgkIxojWsPYKEAIQCA";
	private string VULTURE = "CgkIxojWsPYKEAIQCQ";
	private string ALBATROSS = "CgkIxojWsPYKEAIQCg";
	private string HAWK = "CgkIxojWsPYKEAIQCw";
	private string OWL = "CgkIxojWsPYKEAIQDA";
	private string FALCON = "CgkIxojWsPYKEAIQDQ";
	private string EAGLE = "CgkIxojWsPYKEAIQDg";
	private string PELICAN = "CgkIxojWsPYKEAIQDw";
	private string CONDOR = "CgkIxojWsPYKEAIQEA";
	private string CROW = "CgkIxojWsPYKEAIQEQ";
	private string PARROT = "CgkIxojWsPYKEAIQEg";
	private string FLAMINGO = "CgkIxojWsPYKEAIQEw";
	private string HERON = "CgkIxojWsPYKEAIQFA";

	void Start() 
	{
		PlayerPrefs.SetInt("FireKillings", 0);
		PlayerPrefs.SetInt("ShieldKillings", 0);
	}
	
	void Update () 
	{
		scoreGame = GetComponent<PlayerManager>().score;
		fireIsUsed = GetComponent<PlayerManager>().fireUsed;
		shieldIsUded = GetComponent<PlayerManager>().shieldUsed;

		ScoreManagement();
		AchievementsManagement();

	}

	void ScoreManagement()
	{
		/* OLTREPASSA 100 UCCELLI */
		if(scoreGame == 100)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(SWALLOW, 100.0f, (bool success) =>
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
		}
		/* OLTREPASSA 200 UCCELLI */
		if(scoreGame == 200)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(SPARROW, 100.0f, (bool success) =>
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
		}
		/* OLTREPASSA 300 UCCELLI */
		if(scoreGame == 300)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(HUMMINGBIRD, 100.0f, (bool success) =>
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
		}
		/* OLTREPASSA 400 UCCELLI */
		if(scoreGame == 400)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(PIGEON, 100.0f, (bool success) =>
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
		}/* OLTREPASSA 500 UCCELLI */
		if(scoreGame == 500)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(PHEASANT, 100.0f, (bool success) =>
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
		}/* OLTREPASSA 600 UCCELLI */
		if(scoreGame == 600)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(CRANE, 100.0f, (bool success) =>
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
		}/* OLTREPASSA 700 UCCELLI */
		if(scoreGame == 700)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(QUAIL, 100.0f, (bool success) =>
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
		}/* OLTREPASSA 800 UCCELLI */
		if(scoreGame == 800)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(VULTURE, 100.0f, (bool success) =>
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
		}
		/* OLTREPASSA 900 UCCELLI */
		if(scoreGame == 900)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(ALBATROSS, 100.0f, (bool success) =>
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
		}
		/* COMPLETA IL GIOCO */
		if(scoreGame == 1000)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(HAWK, 100.0f, (bool success) =>
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
		}
		/* COMPLETA IL GIOCO SENZA USARE L'OGGETTO FUOCO */
		if(scoreGame == 1000 && !(fireIsUsed))
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(PARROT, 100.0f, (bool success) =>
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
		}
		/* COMPLETA IL GIOCO SENZA USARE L'OGGETTO SCUDO */
		if(scoreGame == 1000 && !(shieldIsUded))
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(FLAMINGO, 100.0f, (bool success) =>
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
		}
		/* COMPLETA IL GIOCO SENZA USARE ALCUN OGGETTO D'AIUTO */
		if(scoreGame == 1000 && !(fireIsUsed) && !(shieldIsUded))
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(HERON, 100.0f, (bool success) =>
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
		}
	
	}

	void AchievementsManagement()
	{
		/* BRUCIA 10 UCCELLI */
		if(PlayerPrefs.GetInt("FireKillings") == 10)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(OWL, 100.0f, (bool success) =>
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
		}
		/* BRUCIA 75 UCCELLI */
		if(PlayerPrefs.GetInt("FireKillings") == 75)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(FALCON, 100.0f, (bool success) =>
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
		}
		/* BRUCIA 150 UCCELLI */
		if(PlayerPrefs.GetInt("FireKillings") == 150)
		{
			if(Social.localUser.authenticated) //se l utente è stato già autenticato nella piattaforma
			{
				Social.ReportProgress(EAGLE, 100.0f, (bool success) =>
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
		}
		/* PROTEGGITI CON LO SCUDO DA 10 UCCELLI  */
		if(PlayerPrefs.GetInt("ShieldKillings") == 10)
		{
			if(Social.localUser.authenticated) 
			{
				Social.ReportProgress(PELICAN, 100.0f, (bool success) =>
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
		}
		/* PROTEGGITI CON LO SCUDO DA 75 UCCELLI  */
		if(PlayerPrefs.GetInt("ShieldKillings") == 75)
		{
			if(Social.localUser.authenticated) 
			{
				Social.ReportProgress(CONDOR, 100.0f, (bool success) =>
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
		}
		/* PROTEGGITI CON LO SCUDO DA 150 UCCELLI  */
		if(PlayerPrefs.GetInt("ShieldKillings") == 150)
		{
			if(Social.localUser.authenticated) 
			{
				Social.ReportProgress(CROW, 100.0f, (bool success) =>
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
		}

	}
}
