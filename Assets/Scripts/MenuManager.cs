using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	void OnApplicationPause(bool _PAUSED)
	{
		if(_PAUSED == true) //si è usciti dal gioco(premendo il tasto Home)
		{

		}
		else //si è tornati al gioco(dopo che è stato premuto il tasto Home)
		{
			if(PlayerPrefs.GetInt("SoundState") == 0) //se il volume era a 0...
			{
				AudioListener.pause = true; //...rimane a 0
			}
			else //se il volume era a 1...
			{
				AudioListener.pause = false; //...rimane a 1
			}
		}
	}

	void OnApplicationFocus(bool _FOCUSED)
	{

	}

}
