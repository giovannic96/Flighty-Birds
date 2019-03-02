using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fireSprDuration : MonoBehaviour {
	
	private Scrollbar Bar;
	private Image Mask;
	private Image FireUI;
	//private Image Boundary;
	private AudioSource barSound;
	private float seconds = 1; //parte da uno perchè andrà a modificare la dimensione della barra(che parte da 1)
	private Color colorObj;
	public GameObject flamePrefab;
	private GameObject cloneFlame;
	private GameObject pl;
	public float timeDurationFire, timeDurationFlame;

	void Awake()
	{
		pl = GameObject.FindGameObjectWithTag("player");
	}

	void Start()
	{
		colorObj.a =1; //quando il player attiva il fuoco, l'alpha del fuoco è al massimo
		colorObj.r = 255;
		colorObj.g = 255;
		colorObj.b = 255;
		barSound = GameObject.Find("BarSound").GetComponent<AudioSource>();
		Mask = GameObject.FindGameObjectWithTag("maskBarFire").GetComponent<Image>();
		FireUI = GameObject.FindGameObjectWithTag("fireUI").GetComponent<Image>();
		Bar = GameObject.FindGameObjectWithTag("barFire").GetComponent<Scrollbar>();
		//Boundary = GameObject.FindGameObjectWithTag("boundaryBar").GetComponent<Image>();
		StartCoroutine(ShieldTimer()); //inizio il Timer quando viene creato il prefab(void Start)
		StartCoroutine(FlameLaunching()); //inizio la routine del lancio delle fiammelle
		InvokeRepeating("SubtractSeconds", 1.0f, 1.0f); //invoco il metodo ogni preciso secondo
	}
	
	void Update()
	{
		Mask.enabled = true; //attivo la mask della barra
		FireUI.color = colorObj;
		//Boundary.enabled = true; //attivo il bordo della barra
		Bar.size = seconds + 0.03f; //la dimensione della barra è uguale ai secondi(che sottraggo tramite il metodo SubtractSeconds)
		barSound.GetComponent<AudioSource>().enabled = true; //attivo l'audio della barra
	}
	
	IEnumerator ShieldTimer() //ROUTINE
	{
		while(true)//ripeti sempre
		{
			yield return new WaitForSeconds(timeDurationFire); //aspetta tot. di tempo
			Mask.enabled = false; //disattivo la mask della barra
			colorObj.a = 0.15f; //l'alpha del fuoco diventa più bassa
			colorObj.r = 255;
			colorObj.g = 255;
			colorObj.b = 255;
			FireUI.color = colorObj; //il colore del fuoco è uguale al colore(e all'alpha) che ho dato prima
			//Boundary.enabled = false; //disattivo il bordo della barra
			barSound.GetComponent<AudioSource>().enabled = false; //disattivo l'audio della barra
			Bar.size = 1; //la barra è di nuovo piena
			Destroy(this.gameObject); //si distrugge il fuoco
			break; //termino la routine
		}
	}

	IEnumerator FlameLaunching()
	{
		while(true)//ripeti sempre
		{
			yield return new WaitForSeconds(timeDurationFlame); //aspetta tot. secondi per innescare un altra fiammella 
			cloneFlame = Instantiate(flamePrefab, new Vector3(pl.transform.position.x , pl.transform.position.y, pl.transform.position.z + 1), Quaternion.identity) as GameObject; //istanzio il prefab flame 
			cloneFlame.gameObject.SetActive(true); //lo rendo attivo(dopo il countdown si disattiverà)
		}
	}
	
	void SubtractSeconds()
	{
		seconds -= 0.04f; //diminuisco i secondi
	}
	
}