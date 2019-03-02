using UnityEngine;
using System.Collections;

public class SceneTo : MonoBehaviour {
	
	public void StartScene(int numberScene)
	{
		Application.LoadLevel(numberScene);
	}

	public void CloseApp()
	{
		Application.Quit();
	}


}
