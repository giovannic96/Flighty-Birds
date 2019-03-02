using UnityEngine;
using System.Collections;

public class objectSpawn : MonoBehaviour {

	public Transform pl;
	public  GameObject sprite;
	private GameObject spr;
	public float minWaitTime, maxWaitTime;
	public float maxPosY;
	public float minPosY;
	private float timer;
	private float posY;
	public float timeGaming;

	void OnEnable()//quando questo GameObject è attivato(viene disattivato dallo script del Player quando il gioco è in pausa, mentre viene riattivato quando il gioco non è più in pausa)
	{
		timer = Random.Range(minWaitTime - 13, maxWaitTime - 15); //in questo modo si dovranno aspettare tot. secondi anche dall'inizio del gioco, altrimenti gli oggetti spuntano subito ad ogni inizio
	}

	void Start ()
	{
		pl.GetComponent<PlayerManager>();
	}
	
	void Update ()
	{
		PositionYSpawning();
		Vector3 plPos = pl.position;
		float posX = plPos.x + 12;
		timeGaming += 1 * Time.deltaTime; //in questo modo si sincronizza col punteggio(secondi)

		if(!(GameObject.FindGameObjectWithTag("misterybird")))
		{
				if(timer < timeGaming)
				{
					spr = GameObject.Instantiate(sprite, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
					timer = timeGaming + Random.Range(minWaitTime, maxWaitTime);
				}	
		}
		
	}
	
	void PositionYSpawning()
	{
		posY = Random.Range(minPosY,maxPosY);
	}
	
}