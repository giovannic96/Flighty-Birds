using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Transform myTransform;

	public float forwardSpeed;
	public float flapSpeed;

	public float topBoundary, bottomBoundary;

	bool flying = false;

	void Awake()
	{
		myTransform = this.transform;
	}

	void Start()
	{
		rigidbody2D.AddForce(Vector2.up * flapSpeed/0.3f, ForceMode2D.Impulse); //all'inizio dò un piccolo slancio al bird.
	}

	void FixedUpdate()
	{
		MovementBird();

		RotationBird();

		//LIMITI SCENARIO
		if(myTransform.position.y > topBoundary)
		{
			myTransform.rigidbody2D.velocity = new Vector2(0,Mathf.Clamp(myTransform.rigidbody2D.velocity.y, 0, 0.4f));
			myTransform.rigidbody2D.AddForce(Vector2.up * Time.deltaTime);
		}
		else if(myTransform.position.y < bottomBoundary)
		{
			myTransform.rigidbody2D.velocity = new Vector2(0,Mathf.Clamp(myTransform.rigidbody2D.velocity.y, 2, 8));
			myTransform.rigidbody2D.velocity += new Vector2(0,1) * 90 * Time.deltaTime;
		}
	}

	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			flying = true;
		}
	}

	void MovementBird()
	{
		rigidbody2D.AddForce(Vector2.right * forwardSpeed); //il player va verso destra(a prescindere dal tocco dello schermo dell utente)
		if(flying) //mentre vola
		{
			if(myTransform.rigidbody2D.velocity.y < 0) //se la velocità y è < 0 (se il player non tocca lo schermo piano piano il player perde velocità)
			{
				myTransform.rigidbody2D.velocity = new Vector2(myTransform.rigidbody2D.velocity.x, 0); //la velocità rimane 0(non si abbassa oltre lo 0)
			}
			rigidbody2D.AddForce(Vector2.up * flapSpeed, ForceMode2D.Impulse); //se viene toccato lo schermo(flying = true) do una spinta al player verso l alto
			flying = false; //termino la fase di volo(finchè non viene premuto nuovamente lo schermo)
		}
		
		myTransform.rigidbody2D.velocity = new Vector2(0,Mathf.Clamp(myTransform.rigidbody2D.velocity.y, -15, 11)); //la velocità y del player deve stare tra -15 e 11
	}

	void RotationBird()
	{
		float angle = 0; //all'inizio l angolo è di 0 gradi
		if(myTransform.rigidbody2D.velocity.y < 0) //se la velocità y è < 0...
		{
			angle = Mathf.Lerp(0, -90, -myTransform.rigidbody2D.velocity.y / 65); //...l'angolo di rotazione è verso il basso
		}
		else if(myTransform.rigidbody2D.velocity.y > 0)//se la velocità y è > 0...
		{
			angle = Mathf.Lerp(0, 60, myTransform.rigidbody2D.velocity.y / 120); //...l'angolo di rotazione è verso l alto
		}
		transform.rotation = Quaternion.Euler(0, 0, angle); //applica la rotazione(col relativo angolo qua sopra stabilito) al player
	}

}
