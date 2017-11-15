/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Peleador : MonoBehaviour {

	public string nombre;
	public int vida;
	public int mana;
	public int inteligencia;
	public int fuerza;

	public bool sigueVivo;
	public bool esAliado;

	public List<Habilidad> Habilidades;

	static ControladorPelea cp ;





	// Use this for initialization
	void Start () {
		cp = ControladorPelea.singleton;
	}

	public IEnumerator EjecutarAccion(Habilidad habilidad, Transform objetivo){
		ActualizarMana (-habilidad.costoMana);
		if (habilidad.objetivoEsElMismo) {
			objetivo = transform;
		}
		//Aca hay que instanciar la animacion de la habilidad
		if (habilidad.esDeFuerza) {
			
		} 
		else {
			yield return null;
		}
			
	}

	void ActualizarVida(int cantidad){
		vida += cantidad;
		cp.ActualizarInterface();
	}

	void ActualizarMana(int cantidad){
		vida += cantidad;
		cp.ActualizarInterface();
	}

	void ActiualizarInteligencia(int cantidad){
		inteligencia += cantidad;
	}

	void ActiualizarFuerza(int cantidad){
		fuerza += cantidad;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}*/ 
