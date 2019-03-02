using UnityEngine;
using System.Collections;

public class ObjectsMovement : MonoBehaviour {

	private Transform myTransform;
	public float velocitySpeed;
	public float rotationSpeed;

	void Start () 
	{
		myTransform = this.transform;
	}
	
	void Update () 
	{
		myTransform.position -= new Vector3(velocitySpeed,0,0);
		myTransform.Rotate(new Vector3(0,360 * Time.deltaTime / rotationSpeed,0));
		Destroy(this.gameObject, 8f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "player")
		{
			Destroy(this.gameObject);
		}
	}
}
