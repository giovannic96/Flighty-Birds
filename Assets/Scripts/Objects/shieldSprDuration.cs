using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shieldSprDuration : MonoBehaviour {

	private Scrollbar Bar;
	private Image Mask;
	private Image ShieldUI;
	//private Image Boundary;
	private AudioSource barSound;
	private float seconds = 1; //parte da uno perchè andrà a modificare la dimensione della barra(che parte da 1)
	private Color colorObj;
	public float timeDurationShield;

	void Start()
	{
		colorObj.a =1; //quando il player attiva lo scudo, l'alpha dello scudo è al massimo
		colorObj.r = 255;
		colorObj.g = 255;
		colorObj.b = 255;
		barSound = GameObject.Find("BarSound").GetComponent<AudioSource>();
		Mask = GameObject.FindGameObjectWithTag("maskBarShield").GetComponent<Image>();
		ShieldUI = GameObject.FindGameObjectWithTag("shieldUI").GetComponent<Image>();
		Bar = GameObject.FindGameObjectWithTag("barShield").GetComponent<Scrollbar>();
		//Boundary = GameObject.FindGameObjectWithTag("boundaryBar").GetComponent<Image>();
		StartCoroutine(ShieldTimer()); //inizio il Timer quando viene creato il prefab(void Start)
		InvokeRepeating("SubtractSeconds", 1.0f, 1.0f); //invoco il metodo ogni preciso secondo
	}

	void Update()
	{
		print(seconds);
		Mask.enabled = true; //attivo la mask della barra
		ShieldUI.color = colorObj;
		//Boundary.enabled = true; //attivo il bordo della barra
		Bar.size = seconds + 0.05f; //la dimensione della barra è uguale ai secondi(che sottraggo tramite il metodo SubtractSeconds)
		barSound.GetComponent<AudioSource>().enabled = true; //attivo l'audio della barra
	}

	IEnumerator ShieldTimer() //ROUTINE
	{
		while(true)//ripeti sempre
		{
			yield return new WaitForSeconds(timeDurationShield); //aspetta tot. secondi
			Mask.enabled = false; //disattivo la mask della barra
			colorObj.a = 0.15f; //l'alpha dello scudo diventa più bassa
			colorObj.r = 255;
			colorObj.g = 255;
			colorObj.b = 255;
			ShieldUI.color = colorObj; //il colore dello scudo è uguale al colore(e all'alpha) che ho dato prima
			//Boundary.enabled = false; //disattivo il bordo della barra
			barSound.GetComponent<AudioSource>().enabled = false; //disattivo l'audio della barra
			Bar.size = 1; //la barra è di nuovo piena
			Destroy(this.gameObject); //si distrugge lo scudo
			break; //termino la routine
		}
	}

	void SubtractSeconds()
	{
		seconds -= 0.093f; //diminuisco i secondi
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "enemy1" ||  other.tag == "enemy2" || other.tag == "enemy3" || other.tag == "enemy4") //non distrugge il misteryBird e nemmeno il misteryEgg
		{
			PlayerPrefs.SetInt("ShieldKillings", PlayerPrefs.GetInt("ShieldKillings") + 1);
			Destroy(other.gameObject);
		}
		if(other.tag == "egg")
		{
			Destroy(other.gameObject);
		}
	}

}
