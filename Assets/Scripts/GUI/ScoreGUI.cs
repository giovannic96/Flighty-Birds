using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreGUI : MonoBehaviour {

	public float scoreOfGame;
	public Text myText;
	public GameObject scoreGUI;
	private Color startColor;
	private int score;

	void Awake () 
	{
		myText = scoreGUI.GetComponentInChildren<Text>(); 
	}

	void Start()
	{
		startColor = new Color(0.196f,0.196f,0.196f,1.000f);
		myText.color = startColor;
	}
	
	void Update () 
	{
		score = GameObject.FindGameObjectWithTag("scorePoint").GetComponent<scorePointManager>().scoreInt;

		scoreOfGame = score; //score viene aumentato di uno ogni volta che un enemyBird tocca lo scorePoint

		myText.text = " " +scoreOfGame; //il testo del UI Text in alto è uguale allo scoreOfGame
		if(GameObject.FindGameObjectWithTag("misterybird"))
		{
			myText.color = Color.red; //il testo dello score diventa rosso quando c è il misteryBird
		}
		else
		{
			myText.color = startColor; //ritorna normale(nero) quando non c è più il misteryBird
		}
	}

}
