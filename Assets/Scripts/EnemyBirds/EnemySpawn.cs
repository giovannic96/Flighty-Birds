using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public Transform pl;
	public  GameObject sprite;
	public float waitTime;
	public float maxPosY;
	public float minPosY;
	private GameObject spr;
	private float timer;
	private float posY;

	void Start ()
	{
		pl.GetComponent<PlayerManager>();
	}
	
	void Update ()
	{
		PositionYSpawning();
		Vector3 plPos = pl.position;
		float posX = plPos.x + 12;

		if(!(GameObject.FindGameObjectWithTag("misterybird")))
		{
			if(sprite.tag == "enemy1")
			{
				if(timer < Time.time)
				{
					spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
					timer = Time.time + waitTime;
				}
			}
			else if(sprite.tag == "enemy2")
			{
				if(timer < Time.time)
				{
					spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
					timer = Time.time + waitTime;
				}
			}
			else if(sprite.tag == "enemy3")
			{
				if(timer < Time.time)
				{
					spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
					timer = Time.time + waitTime;
				}
			}
			else if(sprite.tag == "enemy4")
			{
				if(timer < Time.time)
				{
					spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
					timer = Time.time + waitTime;
				}
			}
		}

	}

	void PositionYSpawning()
	{
		posY = Random.Range(minPosY,maxPosY);

	}

}
