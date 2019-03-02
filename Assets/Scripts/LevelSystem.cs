using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSystem : MonoBehaviour {

	public Text score_text;
	public ScoreGUI scoreScript;
	public Levels level = Levels.Level1; //all'inizio siamo al livello1.
	public int endLevel1, endLevel2, endLevel3, endLevel4, endLevel5, endLevel6;

	void Awake() 
	{
		score_text = scoreScript.myText;
	}
	
	void Update () 
	{
		if(int.Parse(score_text.text) < endLevel1)
		{
			level = Levels.Level1;
		}
		else if(int.Parse(score_text.text) >= endLevel1 && int.Parse(score_text.text) < endLevel2)
		{
			level = Levels.Level2;
		}
		else if(int.Parse(score_text.text) >= endLevel2 && int.Parse(score_text.text) < endLevel3)
		{
			level = Levels.Level3;
		}
		else if(int.Parse(score_text.text) >= endLevel3 && int.Parse(score_text.text) < endLevel4)
		{
			level = Levels.Level4;
		}
		else if(int.Parse(score_text.text) >= endLevel4 && int.Parse(score_text.text) < endLevel5)
		{
			level = Levels.Level5;
		}
		else if(int.Parse(score_text.text) >= endLevel5 && int.Parse(score_text.text) < endLevel6)
		{
			level = Levels.Level6;
		}
		else
		{
			level = Levels.Level7;
		}
	}

	public enum Levels //enumero una serie di livelli.
	{
		Level1,
		Level2,
		Level3,
		Level4,
		Level5,
		Level6,
		Level7
	}
}
