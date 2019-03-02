
using UnityEngine;
using System.Collections;

public class EggMovement : MonoBehaviour {

	private float timer;
	private float timeOfSpawning;
	Transform egg;
	public float speed;
	public bool isActive;
	private float numb;
	LevelSystem levelScript;
	private float rateSpawnEggs; //valore compreso tra 0 e 1 --> sarebbe la percentuale di spawnamento delle uova.
	public float percentageLevel2,percentageLevel3,percentageLevel4,percentageLevel5,percentageLevel6,percentageLevel7;

	void Awake() //QUANDO VIENE CREATO IL GAMEOBJECT
	{
		isActive = false;
		timer = 0f;
		timeOfSpawning = 3.8f; //ritardo spawnamento uova. 
		numb = Random.value; //restituisce un valore casuale tra 0 e 1.

		/*IMPORTANTE*/ //Per ovviare al problema del prefab, non devo creare una variabile public(xk non funzionerà),ma dargli io il valore quando il prefab viene istanziato.
		levelScript = GameObject.FindGameObjectWithTag("levelSystem").GetComponent<LevelSystem>();
	}

	void Start()
	{
		egg = this.transform;
		egg.GetComponent<SpriteRenderer>().enabled = false;
	}

	void FixedUpdate()
	{
		Vector3 pos = egg.position;
		if(isActive)
		{
			egg.GetComponent<SpriteRenderer>().enabled = true;

			if(levelScript.level == LevelSystem.Levels.Level3)
			{
				pos.y -= speed * 1.1f * Time.deltaTime; //aumento la velocità delle uova in base ai livelli.
			}
			else if(levelScript.level == LevelSystem.Levels.Level4)
			{
				pos.y -= speed * 1.3f * Time.deltaTime; 
			}
			else if(levelScript.level == LevelSystem.Levels.Level5)
			{
				pos.y -= speed * 1.5f * Time.deltaTime; 
			}
			else if(levelScript.level == LevelSystem.Levels.Level6)
			{
				pos.y -= speed * 1.65f * Time.deltaTime; 
			}
			else if(levelScript.level == LevelSystem.Levels.Level7)
			{
				pos.y -= speed * 1.7f * Time.deltaTime; 
			}
			egg.position = pos;
		}
	}

	void Update () 
	{
		EggsPercentage();

		timer += 0.1f;
		if(timer > timeOfSpawning)
		{
			if(numb <= rateSpawnEggs) //con qst sistema determino la probabilità che gli uccelli facciano le uova.
			{
				if(levelScript.level == LevelSystem.Levels.Level3 || levelScript.level == LevelSystem.Levels.Level4 || levelScript.level == LevelSystem.Levels.Level5 || levelScript.level == LevelSystem.Levels.Level6 || levelScript.level == LevelSystem.Levels.Level7 ) //le uova ci saranno a partire dal livello2.
				{
					isActive = true;
				}
			}
			else
			{
				isActive = false;
			}
		}
	}

	void EggsPercentage()
	{
		if(levelScript.level == LevelSystem.Levels.Level2)
		{
			rateSpawnEggs = percentageLevel2; //così un "percentageLevel2" di uova verrano spawnate.
		}
		if(levelScript.level == LevelSystem.Levels.Level3)
		{
			rateSpawnEggs = percentageLevel3;
		}
		if(levelScript.level == LevelSystem.Levels.Level4)
		{
			rateSpawnEggs = percentageLevel4;
		}
		if(levelScript.level == LevelSystem.Levels.Level5)
		{
			rateSpawnEggs = percentageLevel5;
		}
		if(levelScript.level == LevelSystem.Levels.Level6)
		{
			rateSpawnEggs = percentageLevel6;
		}
		if(levelScript.level == LevelSystem.Levels.Level7)
		{
			rateSpawnEggs = percentageLevel7;
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "ground")
		{
			Destroy(this.gameObject);
		}
		if(collider.tag == "shieldForEggsSpr")
		{
			Destroy(this.gameObject);
		}
	 	
	}

}
