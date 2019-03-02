using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private bool toggle;
	private Rect rectToggle, rectBox;
	private int soundState;
	public GUISkin toggleSkin;

	void Start()
	{
		rectToggle = new Rect(Screen.width/15, Screen.height/38, 50, 50);
		rectBox = new Rect(Screen.width/21, Screen.height/51, 62, 60);
	}

	void Awake()
	{
		soundState = PlayerPrefs.GetInt("SoundState");

		if(soundState == 1)
		{
			toggle = true;
		} 
		else 
		{
			toggle = false;
		}

	}

	void OnGUI()
	{
		GUI.Box(rectBox, "", toggleSkin.box);
		toggle = GUI.Toggle(rectToggle, toggle, "", toggleSkin.customStyles[0]);

		if(toggle == false) 
		{
			AudioListener.pause = true;
			PlayerPrefs.SetInt("SoundState", 0);
		} 
		else 
		{
			AudioListener.pause = false;
			PlayerPrefs.SetInt ("SoundState", 1);
		}
	}
}