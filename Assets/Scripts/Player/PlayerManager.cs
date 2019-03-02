using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private Transform myTransform;
	public bool enemyCollision = false;
	public bool groundCollision = false;
	public Canvas pauseCanvas;
	public GameObject scoreCanvas;
	public float score;
	public Text score_text, highScore_text;
	public ScoreGUI script;
	public GameObject ScoreObj, HighScoreObj;
	public bool pauseGame = false;
	private bool doubleClick = false;
	public AudioSource flap1Audio, flap2Audio;
	public AudioSource deathAudio;
	public float WaitForAds;
	public float WaitForMisteryBird;
	public GameObject shield;
	public GameObject fire;
	private GameObject cloneShield;
	private GameObject cloneFire;
	public GameObject spawnFireObject;
	public GameObject spawnShieldObject;
	public bool fireUsed, shieldUsed;

	void Awake()
	{
		myTransform = this.transform;
		score_text = ScoreObj.GetComponentInChildren<Text>();
		highScore_text = HighScoreObj.GetComponentInChildren<Text>();
	}

	void Start ()
	{
		score = 0;
		WaitForAds = Random.value;
		WaitForMisteryBird = Random.value;
		fireUsed = false;
		shieldUsed = false;
	}

	void Update () 
	{
		ScoreManager();

		DoubleFlap();

		/* PAUSE GAME MANAGER*/
		if(pauseGame)
		{
			RemoveComponents();
		}
		else if(!(pauseGame))
		{
			ShowComponents();
		}

	}

	void ShowComponents()
	{
		scoreCanvas.gameObject.SetActive(true); //mostro il punteggio in alto
		pauseCanvas.enabled = false; //disabilito il menu di pausa
		myTransform.GetComponent<SpriteRenderer>().enabled = true; //rendo visibile il player
		spawnFireObject.SetActive(true); //attivo il gameobject dello spawnamento dell'oggetto fuoco
		spawnShieldObject.SetActive(true); //attivo il gameobject dello spawnamento dell'oggetto fuoco
		Time.timeScale = 1; //riprendo il gioco(che era "fermo")
		AudioListener.volume = 1; //riattivo gli audio
	}

	void RemoveComponents()
	{
		GameObject[] eggs =  GameObject.FindGameObjectsWithTag("egg"); //ottengo tutti i GameObject uova presenti sulla scena.
		int lenght = eggs.Length; //ottengo il numero delle uova presenti in quel momento sulla scena.
		for(int i = 0; i < lenght; i++)
		{
			eggs[i].SetActive(false); //tolgo tutte le uova presenti sulla scena.
		}
		GameObject misteryEgg = GameObject.FindGameObjectWithTag("misteryegg"); //vedo se c è il misteryEgg mentre il player è morto
		if(misteryEgg != null)
		{
			misteryEgg.SetActive(false); //tolgo il misteryEgg
		}
		score_text.text = "SCORE: " + Mathf.Floor(score) + " "; //scrivo lo score attuale nel meu di pausa
		highScore_text.text = "BEST SCORE: " + Mathf.Floor(PlayerPrefs.GetFloat("Highscore")) + " "; //scrivo l highscore nel menu di pausa
		pauseCanvas.enabled = true; //attivo il menu di pausa
		myTransform.GetComponent<SpriteRenderer>().enabled = false; //rendo invisibile il player
		if(GameObject.FindGameObjectWithTag("shield") != null)
		{
			cloneShield.SetActive(false); //disattivo lo scudo(se il player ce l'aveva)
		}
		if(GameObject.FindGameObjectWithTag("fire") != null)
		{
			cloneFire.SetActive(false); //disattivo il fuoco(se il player ce l'aveva)
		}
		GameObject[] flames = GameObject.FindGameObjectsWithTag("flame"); //ottengo tutti i GameObject flames presenti sulla scena.
		int lenght2 = flames.Length; //ottengo il numero di quanti ce ne sono nella scena
		for(int j = 0; j < lenght2; j++)
		{
			flames[j].SetActive(false); //tolgo tutte le fiammelle presenti sulla scena
		}
		spawnFireObject.SetActive(false); //disattivo il gameobject dello spawnamento dell'oggetto fuoco
		spawnShieldObject.SetActive(false); //disattivo il gameobject dello spawnamento dell'oggetto scudo
		scoreCanvas.gameObject.SetActive(false); //disattivo il punteggio che spunta durante il gioco
		Time.timeScale = 0; //blocco il gioco
		AudioListener.volume = 0; //stacco il volume di tutti gli audio
	}

	void DeathBird()
	{
		deathAudio.Play(); 
		pauseGame = true;
	}

	void ScoreManager()
	{
		score = script.scoreOfGame;
		if(score > PlayerPrefs.GetFloat("Highscore"))
		{
			PlayerPrefs.SetFloat("Highscore", score);
		}

	}

	void DoubleFlap()
	{
		if(!(pauseGame))
		{
			if(Input.GetButtonDown("Fire1"))
			{
				if(!(doubleClick))
				{
					flap1Audio.Play();
					doubleClick = true;
				}
				else if(doubleClick)
				{
					flap2Audio.Play();
					doubleClick = false;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "enemy1" || collider.tag == "enemy2" || collider.tag == "enemy3" || collider.tag == "enemy4" || collider.tag == "egg" || collider.tag == "misterybird" || collider.tag == "misteryegg")
		{
			enemyCollision = true;
			DeathBird();
		}

		else if(collider.tag == "ground")
		{
			groundCollision = true;
			DeathBird();
		}

		if(collider.tag == "shield_obj")
		{
			cloneShield = Instantiate(shield, new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z + 1), Quaternion.identity) as GameObject; //creo il prefab fuoco nella stessa posizione del player(aumento un po l asse z per far si che si veda dietro il player)
			cloneShield.gameObject.SetActive(true); //lo rendo attivo(dopo il countdown si disattiverà)
			cloneShield.transform.parent = myTransform; //lo rendo un child del player
			shieldUsed = true;
		}
		if(collider.tag == "fire_obj")
		{
			cloneFire = Instantiate(fire, new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z + 1), Quaternion.identity) as GameObject; //creo il prefab scudo nella stessa posizione del player(aumento un po l asse z per far si che si veda dietro il player)
			cloneFire.gameObject.SetActive(true); //lo rendo attivo(dopo il countdown si disattiverà)
			cloneFire.transform.parent = myTransform; //lo rendo un child del player
			fireUsed = true;
		}
	
	}

}
