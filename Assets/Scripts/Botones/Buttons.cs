using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {


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

	}

	void OnMouseDown(){
		GameManager.basicAttack = "y";
	}

}
