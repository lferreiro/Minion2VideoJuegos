using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour {

	public Habilidad ataque;

	public Personaje personaje;


	// Use this for initialization
	void Start () {

		GetComponentInChildren<Text> (). text = ataque.nombre;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(){

		//personaje.castearHabilidad (ataque);
		Debug.Log("Click");
		Debug.Log (GameManager.whichTurn);
	}

}
