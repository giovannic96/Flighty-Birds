using UnityEngine;
using System.Collections;

public class FlamesMovement : MonoBehaviour {

	private GameObject pl;
	private float targetX, targetY;
	public float speedFlames;

	void Awake()
	{
		pl = GameObject.FindGameObjectWithTag("player");
	}

	void Start () 
	{
		targetX = pl.transform.position.x + 11;
		targetY = Random.Range(pl.transform.position.y - 6.5f, pl.transform.position.y + 6.9f);
	}
	
	void Update () 
	{
		Vector3 pos = this.transform.position;
		pos = Vector3.MoveTowards(this.transform.position, new Vector3(targetX, targetY, 0),  speedFlames * Time.deltaTime);
		pos.y = Mathf.Lerp(pos.y, Random.Range(pos.y - 0.1f, pos.y + 0.1f), 2);
		this.transform.position = pos;

		if(this.transform.position.x > pl.transform.position.x + 10)
		{
			Destroy(this.gameObject);
		}

		if(this.transform.position.y > 7.2f)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "enemy1" || other.tag == "enemy2" || other.tag == "enemy3" || other.tag == "enemy4")
		{
			PlayerPrefs.SetInt("FireKillings", PlayerPrefs.GetInt("FireKillings") + 1);
			Destroy(other.gameObject);
			Destroy(this.gameObject, 0.1f);
		}

		if(other.tag == "egg")
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject, 0.1f);
		}

		if(other.tag == "ground")
		{
			Destroy(this.gameObject);
		}
	}

}
