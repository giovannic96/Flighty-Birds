using UnityEngine;
using System.Collections;

public class scorePointManager : MonoBehaviour {

	GameObject pl;
	public int scoreInt; 
	public int maxScore;

	void Awake()
	{
		pl = GameObject.FindGameObjectWithTag("player"); 
	}
	
	void Update () 
	{
		this.transform.position = new Vector3(pl.transform.position.x - 1f, 0, 0); //movimento dietro al player

		if(scoreInt == maxScore) //se ha raggiunto il massimo dei punti(ha completato il gioco)
		{
			PlayerManager other = (PlayerManager) pl.GetComponent(typeof(PlayerManager)); //ottengo lo script PlayerManager del Player
			other.pauseGame = true; //metto il gioco in pausa
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "enemy1" || other.tag == "enemy2" || other.tag == "enemy3" || other.tag == "enemy4" )
		{
			scoreInt += 1;
		}
	}

}
