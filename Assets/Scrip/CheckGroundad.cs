using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase fue asignada al collayer circular
public class CheckGroundad : MonoBehaviour {

	//Declaramos el objecto de la clase player
	PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GetComponentInParent<PlayerController> ();
	}

	//Metodo para saber si hay una collision
	void OnCollisionStay2D(Collision2D coll){
		if(coll.collider.tag == "Ground")
			playerController.groundad = true;
	}

	//Metodo para saber si dejo de estar en la collision
	void OnCollisionExit2D(Collision2D coll){
		if(coll.collider.tag == "Ground")
			playerController.groundad = false;
	}
}
