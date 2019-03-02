using UnityEngine;
using System.Collections;

public class MisteryBirdMovement : MonoBehaviour {
	
	Transform myTransform;
	public float enemySpeed;
	public bool IsInScene;

	void Awake()
	{
		myTransform = this.transform;
	}
	
	void Update ()
	{
		myTransform.position -= new Vector3(enemySpeed,0,0);	
		Destroy(this.gameObject, 6f);
	}
		
	
}
