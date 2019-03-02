using UnityEngine;
using System.Collections;

public class GroundLooper : MonoBehaviour {

	public int numGroundPanels = 3;
	public int numMountainPanels = 1;
	public int numBackgroundPanels = 1;

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("Triggered: " + collider.name);

		float widthOfObject = ((BoxCollider2D)collider).size.x;
		Vector3 pos = collider.transform.position;

		if(collider.tag == "ground")
		{
			pos.x += widthOfObject * numGroundPanels - widthOfObject/2f;
		}
		else if(collider.tag == "mountain")
		{
			pos.x += widthOfObject * numMountainPanels - widthOfObject/2f;
		}
		else if(collider.tag == "background")
		{
			pos.x += widthOfObject * numBackgroundPanels - widthOfObject/2f;
		}
		collider.transform.position = pos;
	}

}
