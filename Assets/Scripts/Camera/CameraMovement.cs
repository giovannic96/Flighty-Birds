using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform player;
	private float offsetX;

	void Start () 
	{
		GameObject pl = GameObject.FindGameObjectWithTag("player");
		if(pl == null)
		{
			Debug.LogError("Nessun GameObject Player trovato!");
			return;
		}

		player = pl.transform;
		offsetX = transform.position.x - player.position.x - 0.5f;
	}
	
	void Update () 
	{
		if(player != null)
		{
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}

	}
}
