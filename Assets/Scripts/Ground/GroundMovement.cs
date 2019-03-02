using UnityEngine;
using System.Collections;

public class GroundMovement : MonoBehaviour {

	public float speed = 0.9f;
	
	void FixedUpdate () 
	{
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
	}
}
