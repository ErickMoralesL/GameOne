using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxVelocity = 5f;
	public float speed = 20f;
	public bool groundad;
	public float jumpForce = 9.25f;

	private Rigidbody2D rgb2D;
	private Animator animator;
	private bool jump;

	// Use this for initialization
	void Start () {
		groundad = false;
		rgb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("speed",Mathf.Abs(rgb2D.velocity.x));
		animator.SetBool ("Grundead", groundad);

		if(Input.GetKeyDown(KeyCode.UpArrow) && groundad){
			jump = true;
		}
	}

	void FixedUpdate(){

		//Ahora como se agrego un material que no genera ficción
		//lo que sera sera generar una serta friccion en el personaje

		Vector3 fixedVelocity = rgb2D.velocity;
		fixedVelocity.x *= 0.89f;

		if (groundad)
			rgb2D.velocity = fixedVelocity;

		//Sabe si el usuario esta precionando una flecha horizontal <- ->
		float horizontal = Input.GetAxis ("Horizontal");

		//AddForce resibe el parametro de movimiento y puede tambien recibir el impulso
		rgb2D.AddForce (Vector2.right * speed * horizontal);

		//El valor clamp regresa los limites superirores e inferiorees que puede alcanazar una variable
		float horizontalVelocity = Mathf.Clamp (rgb2D.velocity.x, -maxVelocity,maxVelocity);
		rgb2D.velocity =  new Vector2(horizontalVelocity,rgb2D.velocity.y);

		//Cambiamos al presonaje de direccion afectando su valor factorial
		if (horizontal > 0.1f) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}

		if (horizontal < -0.1) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		if (jump) {
			rgb2D.velocity = new Vector2 (rgb2D.velocity.x, 0);
			rgb2D.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
			jump = false;
		}
	}

	// Con este metodo sabremos si nuestro personaje aun es visible en el esenario
	void OnBecameInvisible(){
		transform.position = new Vector3 (-2,0,0);
	}
}
