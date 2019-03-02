using UnityEngine;
using System.Collections;

public class ParticleSortingLayer : MonoBehaviour {

	public int orderInLayer;

	void Start () 
	{
		particleSystem.renderer.sortingLayerName = "Objects";
		particleSystem.renderer.sortingOrder = orderInLayer;
	}

}
