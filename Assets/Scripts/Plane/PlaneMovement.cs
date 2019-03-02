using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {

	Transform planeTransform;
	public Transform pl;

	public static PlaneMovement current;
	public float speed;
	float pos = 0;

	void Start ()
	{
		planeTransform = this.transform;
		pl.GetComponent<PlayerManager>();
		current = this;
		Time.timeScale = 1; //devo mettere il timescale a 1 perchè quando il gioco va in pausa(il player ha perso) il timescale diventa 0, e se si torna nel menu principale...
		//...il timescale rimane a 0(e ad es. le animazioni dei pulsanti non funzionano)
	}
	
	void Update () 
	{
		planeTransform.position = new Vector3(pl.position.x, 0, 0);

		pos += speed;
		if(pos > 1.0f)
		{
			pos -= 1.0f;
		}
		renderer.material.mainTextureOffset = new Vector2(pos, 0);
	}
}
