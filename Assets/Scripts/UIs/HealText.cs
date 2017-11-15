using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealText : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<Renderer> ().sortingOrder = 20;
		GetComponent<TextMesh> ().text = ControladorPelea.currentHeal;
		Destroy (gameObject, 1);

	}

	// Update is called once per frame
	void Update () {

	}
}
