using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class creditsMenuMovement : MonoBehaviour {
	
	private Transform myTrans;
	public float vel;
	public Text text1, text2;
	Vector3 pos;

	void Start () 
	{
		myTrans = this.transform;
		pos.x = myTrans.position.x;
		pos.y = myTrans.position.y;
		pos.z = myTrans.position.z;
		Time.timeScale = 1; //devo mettere il timescale a 1 perchè quando il gioco va in pausa(il player ha perso) il timescale diventa 0, e se si torna nel menu principale...
		//...il timescale rimane a 0(e ad es. le animazioni dei pulsanti non funzionano)
	}
	
	void Update ()
	{
		pos.y -= vel * Time.deltaTime; //si muovono verso il basso
		myTrans.position = pos;
		
		if(pos.y <= 320) //se si trovano circa a metà scenario...
		{
			if(pos.y <= -10) //alla fine dello scenario...
			{
				myTrans.position = new Vector3(0,-10,0); //...rimangono sotto lo scenario
			}
			text1.GetComponent<UnityEngine.UI.Text>().CrossFadeAlpha(255f,1f,false); //spunta la scritta "Offered By" con un effetto Fade In alpha 
			text2.GetComponent<UnityEngine.UI.Text>().CrossFadeAlpha(255f,3f,false); //spunta la scritta "JohGames" con un effetto Fade In alpha(con un po piu di ritardo)
		}

	}

}
