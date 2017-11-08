using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPelea : MonoBehaviour {

	public List<Peleador> peleadores;

	public static ControladorPelea singleton;

	public Text textoGUI;

	public void ActualizarInterface(){

		textoGUI.text = "";
		foreach (var peleador in peleadores) {
			textoGUI.text += "<color=" + (peleador.esAliado ? "lime" : "red" ) + ">" +
				peleador.nombre + " HP: " + peleador.vida + "/100 MANA: " + peleador.mana + "/100.</color>\n";	
		}
	}

	// Use this for initialization
	void Awake () {

		if (singleton != null) {
			Destroy (gameObject);
			return;
		}
		 
		singleton = this;
	}

	void Start(){
		ActualizarInterface ();
		StartCoroutine ("Bucle");
	}
	
	// Update is called once per frame
	IEnumerator Bucle () {

		while (true) {
			foreach (var peleador in peleadores) {

				IEnumerator ataque = null;

				if (peleador.sigueVivo) {
					if (peleador.esAliado) {
					} 
					else {
						ataque = peleador.EjecutarAccion (
							peleador.Habilidades [Random.Range (0, peleador.Habilidades.Count)], 
							peleadores [Random.Range (0, peleadores.Count)].transform);
					}
				}

				while (ataque == null) {
					yield return null;
				}

				StartCoroutine (ataque);
			}

		}
	}
}
