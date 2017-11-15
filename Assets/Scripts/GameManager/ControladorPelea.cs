using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPelea : MonoBehaviour {

	public List<Personaje> personajes;
	public List<Personaje> aliados;

	public static ControladorPelea singleton;

	public static string currentDamage = "0";
	public static string currentHeal = "0";
	public static string currentMana = "0";
		

	public Button buttonPrefab;

	public Transform panelDeHabilidades;

	public bool defeated = false;

	List<Button> poolBotones = new List<Button>();


	// Use this for initialization
	void Awake () {

		if (singleton != null) {
			Destroy (gameObject);
			return;
		}
		 
		singleton = this;
	}

	void Start(){
		StartCoroutine ("Bucle");
	}
	
	// Update is called once per frame
	IEnumerator Bucle(){


		
		while (true) {

			if (!aliados [0].sigueVivo && !aliados [1].sigueVivo) {
				defeated = true;
				Debug.Log ("Defeat");
				personajes[2].destruirPanel();
				Destroy (panelDeHabilidades.gameObject);
				GetComponent<Renderer> ().sortingOrder = 20;
				gameObject.transform.position = new Vector3 (0, 0,20);
				break;
			}
			
			foreach (var personaje in personajes) {

				IEnumerator c = null;

				for (int i = 0; i < poolBotones.Count; i++) {

					poolBotones [i].gameObject.SetActive (false);
				}


				if (personaje.sigueVivo) {
					
					if (personaje.esAliado) {
						
						foreach (var habilidad in personaje.habilidades) {
							
							Button b = null;
							for (int i = 0; i < poolBotones.Count; i++) {
								
								if (!poolBotones [i].gameObject.activeInHierarchy) {
									b = poolBotones [i];

								}

							}
							b = Instantiate (buttonPrefab, panelDeHabilidades);
							b.transform.position = Vector3.zero;
							b.transform.localScale = Vector3.one;
							poolBotones.Add (b);
							b.gameObject.SetActive (true);
							b.onClick.RemoveAllListeners ();
							b.GetComponentInChildren<Text> ().text = habilidad.nombre;
							if (personaje.MANA <= habilidad.costoMana) {
								b.interactable = false;
							} else {
								
								b.interactable = true;
								b.onClick.AddListener (() => {

									for (int j = 0; j < poolBotones.Count; j++) {

										poolBotones [j].gameObject.SetActive (false);
									}
								
									c = personaje.castearHabilidad (habilidad);
								});

							}

						}
					} 
					else {

						yield return new WaitForSeconds (0.5f);
						Habilidad ataque = personaje.habilidades [Random.Range (0, personaje.habilidades.Count)];
						if (ataque.isSingleTarget) {
							int random = Random.Range (0, aliados.Count);
							Personaje objetivo = ataque.objetivos [random];
							if (objetivo.sigueVivo) {
								c = personaje.castearHabilidad (ataque, objetivo);
							} else {
								while (!objetivo.sigueVivo) {
									objetivo = ataque.objetivos [Random.Range (0, ataque.objetivos.Count)];
								}
								c = personaje.castearHabilidad (ataque, objetivo);
							}


						} 
						else {
							c = personaje.castearHabilidad (ataque);
						}

					}

					while (c == null) {
						yield return null;
					}

					yield return StartCoroutine (c);
				} 
			}
		}
	}
}
