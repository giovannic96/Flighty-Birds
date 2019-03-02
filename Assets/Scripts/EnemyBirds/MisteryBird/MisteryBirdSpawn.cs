using UnityEngine;
using System.Collections;

public class MisteryBirdSpawn : MonoBehaviour {
	
	public Transform pl;
	public  GameObject sprite;	
	private GameObject spr;
	private float timer;
	private float posY;
	private bool IsCreated1, IsCreated2, IsCreated3, IsCreated4, IsCreated5, IsCreated6, IsCreated7, IsCreated8, IsCreated9 = false;
	public ScoreGUI scoreScript;
	private float score;

	void Start ()
	{
		pl.GetComponent<PlayerManager>(); 
	}
	
	void Update ()
	{
		score = scoreScript.scoreOfGame;

		Vector3 plPos = pl.position;
		float posX = plPos.x + 16;
		float posY = 4.6f;

		if(sprite.tag == "misterybird")
		{
			if(score == 100 && !(IsCreated1))
			{
				spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
				IsCreated1 = true;
				IsCreated2 = false;
			}
			if(score == 200 && !(IsCreated2))
			{
			 	spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
				IsCreated2 = true;
				IsCreated3 = false;
			}
			if(score == 300 && !(IsCreated3))
			{
				spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
				IsCreated3 = true;
				IsCreated4 = false;
			}
			if(score == 400 && !(IsCreated4))
			{
				spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
				IsCreated4 = true;
				IsCreated5 = false;
			}
			if(score == 500 && !(IsCreated5))
			{
				spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
				IsCreated5 = true;
				IsCreated6 = false;
			}
			if(score == 600 && !(IsCreated6))
			{
				spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
				IsCreated6 = true;
				IsCreated7 = false;
			}
			if(score == 700 && !(IsCreated7))
			{
				spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
				IsCreated7 = true;
				IsCreated8 = false;
			}
			if(score == 800 && !(IsCreated8))
			{
				spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
				IsCreated8 = true;
				IsCreated9 = false;
			}
			if(score == 900 && !(IsCreated9))
			{
				spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
				IsCreated9 = true;
			}
		
		}

	}

	}
		
