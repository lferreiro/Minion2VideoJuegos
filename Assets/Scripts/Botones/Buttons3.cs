﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons3 : MonoBehaviour {

	public Sprite iceSpecial;
	public Sprite swordSpecial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.whichTurn == 3 || GameManager.whichTurn == 4 || GameManager.whichTurn == 5) {
			GetComponent<Renderer> ().sortingOrder = -1;
		}
		else {
			GetComponent<Renderer> ().sortingOrder = 20;
		}

		if (GameManager.whichTurn == 1) {
			GetComponent<SpriteRenderer> ().sprite = iceSpecial;
		}

		if (GameManager.whichTurn == 2) {
			GetComponent<SpriteRenderer> ().sprite = swordSpecial;
		}
		
	}

	void OnMouseDown(){
		GameManager.thirdAttack = "y";
	}
}
