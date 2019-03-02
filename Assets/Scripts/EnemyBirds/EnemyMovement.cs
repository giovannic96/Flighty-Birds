using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	Transform myTransform;
	private float enemySpeed;
	public float velocityLevel1,velocityLevel2,velocityLevel3,velocityLevel4,velocityLevel5,velocityLevel6,velocityLevel7;
	private LevelSystem levelScript2;

	void Awake()
	{
		myTransform = this.transform;
		levelScript2 = GameObject.FindGameObjectWithTag("levelSystem").GetComponent<LevelSystem>();
	}

	void Update ()
	{
		SpeedControl();

		myTransform.position -= new Vector3(enemySpeed,0,0);
		if(myTransform.position.y >= 6.3f)
		{
			myTransform.position -= new Vector3(enemySpeed*1.5f,0,0);
		}
		if(GameObject.FindGameObjectWithTag("misterybird"))
		{
			myTransform.position -= new Vector3(enemySpeed*0.1f,0.06f,0);
			Quaternion newRotation = Quaternion.AngleAxis(60, Vector3.forward);
			myTransform.rotation= Quaternion.Slerp(myTransform.rotation, newRotation, 0.02f); 
		}

		Destroy(this.gameObject, 4.8f);

	}

	void SpeedControl()
	{
		if(levelScript2.level == LevelSystem.Levels.Level1)
		{
			enemySpeed = velocityLevel1;
		}
		else if(levelScript2.level == LevelSystem.Levels.Level2)
		{
			enemySpeed = velocityLevel2;
		}
		else if(levelScript2.level == LevelSystem.Levels.Level3)
		{
			enemySpeed = velocityLevel3;
		}
		else if(levelScript2.level == LevelSystem.Levels.Level4)
		{
			enemySpeed = velocityLevel4;
		}
		else if(levelScript2.level == LevelSystem.Levels.Level5)
		{
			enemySpeed = velocityLevel5;
		}
		else if(levelScript2.level == LevelSystem.Levels.Level6)
		{
			enemySpeed = velocityLevel6;
		}
		else if(levelScript2.level == LevelSystem.Levels.Level7)
		{
			enemySpeed = velocityLevel7;
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "ground")
		{
			Destroy(this.gameObject);
		}
	}


}
