using UnityEngine;
using System.Collections;

public class MisteryEggMovement : MonoBehaviour {
	
	private float timer;
	private float timeOfSpawning;
	Transform egg;
	public float speed;
	private bool isActive;

	void Awake() 
	{
		isActive = false;
		timer = 0f;
		timeOfSpawning = 15f; //ritardo spawnamento uova. 
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
			pos.y -= speed * Time.deltaTime;
			egg.position = pos;
		}
	}
	
	void Update () 
	{
		timer += 0.1f;
		if(timer > timeOfSpawning)
		{
			isActive = true;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "ground")
		{
			Destroy(this.gameObject);
		}
	}
	
}