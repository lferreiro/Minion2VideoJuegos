using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Personaje : MonoBehaviour {

	public string nombre;

	public int HP = 100;
	public int MANA = 100;
	public int Inteligence = 30;
	public int Strenght = 10;
	public int magicResist = 10;
	public int strResit = 5;


	public List<Transform> enemigos;
	public List<Transform> Aliados;

	public Transform dmgObj;
	public Transform manaObj;
	public Transform healObj;

	public bool esAliado;

	public bool sigueVivo = true;

	public Slider HPSlider;
	public Slider ManaSlider;
	public Text NameText;
	public GameObject HPMANAPanel;

	public bool alreadyAttacked = false;

	public bool manaUser = true;

	public List<Habilidad> habilidades;





	// Use this for initialization
	void Start () {

		NameText.text = nombre;

		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.whichTurn == 4 || GameManager.whichTurn == 5) {
			Destroy (HPMANAPanel);
		}

		if (HP <= 0) {
			Destroy (HPMANAPanel);
			Destroy (gameObject);
			sigueVivo = false;
		}

		if (esAliado && HP > 100) {
			HP = 100;
			HPSlider.value = 100;
		}
			
	}
		


	void ApplyHeal(int healAmmount){

		HPSlider.value += healAmmount;
		this.HP += healAmmount;

	}

	public void ApplyDamage(int damage){

		HPSlider.value -= damage;
		this.HP -= damage;
	}

	public IEnumerator castearHabilidad(Habilidad ataque){

		ControladorPelea.currentMana =  ataque.costoMana.ToString();


		if (manaUser) {
			
			MANA -= ataque.costoMana;
			ManaSlider.value -= ataque.costoMana;
			Instantiate (manaObj, gameObject.transform.position, manaObj.rotation);
		}

		if (ataque.isHeal) {
			curarObjetivos (ataque);
			yield return new WaitForSeconds (ataque.animationDuration);

		} 

		else {
			int fallo = Random.Range (0, 100);
			if (ataque.precision >= fallo) {
				foreach (Personaje personaje in ataque.objetivos) {
					if (personaje.sigueVivo) {
						int danio = calcularDanio (ataque, personaje);
						ControladorPelea.currentDamage = danio.ToString ();
						personaje.HP -= danio;
						personaje.HPSlider.value -= danio;
						Instantiate (dmgObj, personaje.transform.position, dmgObj.rotation);
						personaje.GetComponent<Animator> ().SetTrigger (ataque.trigger);
						yield return new WaitForSeconds (ataque.animationDuration);
					}
				}
			} 
			else {
				foreach (Personaje personaje in ataque.objetivos) {
					if (personaje.sigueVivo) {
						int danio = 0;
						ControladorPelea.currentDamage = "Miss ";
						personaje.HP -= danio;
						personaje.HPSlider.value -= danio;
						Instantiate (dmgObj, personaje.transform.position, dmgObj.rotation);
						personaje.GetComponent<Animator> ().SetTrigger (ataque.trigger);
						yield return new WaitForSeconds (ataque.animationDuration);
					}
				}	
			}
		}
		yield return new WaitForSeconds (0.5f);
	}



	public IEnumerator castearHabilidad(Habilidad ataque, Personaje objetivo){


		int fallo = Random.Range (0, 100);


		if (ataque.precision >= fallo) {

			ControladorPelea.currentMana = ataque.costoMana.ToString ();
			ControladorPelea.currentDamage = calcularDanio (ataque, objetivo).ToString ();
			

			if (manaUser) {

				MANA -= ataque.costoMana;
				ManaSlider.value -= ataque.costoMana;
				Instantiate (manaObj, gameObject.transform.position, manaObj.rotation);
			}


			if (objetivo.sigueVivo) {
				objetivo.HP -= ataque.damage;
				objetivo.HPSlider.value -= ataque.damage;
				Instantiate (dmgObj, objetivo.transform.position, dmgObj.rotation);
				objetivo.GetComponent<Animator> ().SetTrigger (ataque.trigger);
				yield return new WaitForSeconds (ataque.animationDuration);
			}



		}

		else {
			ControladorPelea.currentMana = ataque.costoMana.ToString ();
			ControladorPelea.currentDamage = "Miss";

			if (manaUser) {

				MANA -= ataque.costoMana;
				ManaSlider.value -= ataque.costoMana;
				Instantiate (manaObj, gameObject.transform.position, manaObj.rotation);
			}

			if (objetivo.sigueVivo) {
				objetivo.HP -= 0;
				objetivo.HPSlider.value -= 0;
				Instantiate (dmgObj, objetivo.transform.position, dmgObj.rotation);
				objetivo.GetComponent<Animator> ().SetTrigger (ataque.trigger);
				yield return new WaitForSeconds (ataque.animationDuration);
			}

			
		}

		yield return new WaitForSeconds (0.5f);

	}



	public int calcularDanio(Habilidad ataque, Personaje personaje){
		int danio;
		if (ataque.esDeFuerza) {
			danio =  ataque.damage - personaje.strResit ;
		} 
		else {
			danio =  ataque.damage - personaje.magicResist;
		}
		return danio;
		
	}




	public void destruirPanel(){
		
		Destroy (HPMANAPanel);

	}

	public void curarObjetivos(Habilidad ataque){

		int curacion = ataque.damage ;
		ControladorPelea.currentHeal = curacion.ToString ();

		foreach (Personaje personaje in ataque.objetivos) {
			if (personaje.sigueVivo) {
				
				ControladorPelea.currentHeal = curacion.ToString ();
				personaje.HP += curacion;
				personaje.HPSlider.value += curacion;
				Instantiate (healObj, personaje.transform.position, healObj.rotation);
				personaje.GetComponent<Animator> ().SetTrigger (ataque.trigger);
			}
		}
	}


}
