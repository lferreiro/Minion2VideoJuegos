using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Jastra : MonoBehaviour {

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

	public Slider HPSlider;
	public Slider ManaSlider;
	public Text NameText;
	public GameObject HPMANAPanel;

	// Use this for initialization
	void Start () {

		NameText.text = "Jastra";
		
	}
	
	// Update is called once per frame
	void Update () {


		if (HP <= 0) {
			Destroy (HPMANAPanel);
			Destroy (gameObject);
			GameManager.jastraAlive = "dead";
		}

		if (HP > 100) {
			HP = 100;
			HPSlider.value = 100;
		}

		Transform enemy = enemigos[0];
		int ataqueMod = Random.Range (0, 10);

		if (((Input.GetKeyDown ("1")) || GameManager.basicAttack == "y") && (GameManager.whichTurn == 1)) {
			
			GameManager.currentMana = 0;
			GameManager.basicAttack = "n";
			Instantiate (manaObj, gameObject.transform.position, manaObj.rotation);

			enemy.GetComponent<Animator>().SetTrigger("slash");
			if (ataqueMod == 1) {
				StartCoroutine (returnJastra (0, enemy));
			} 
			else if (ataqueMod == 2) {
				StartCoroutine (returnJastra (2 * Strenght, enemy));
			} 
			else {
				StartCoroutine (returnJastra (Strenght, enemy));
			}
				

		}
		if (((Input.GetKeyDown ("2")) || GameManager.secondAttack == "y") && (GameManager.whichTurn == 1) && this.MANA >= 25) {
			GameManager.secondAttack = "n";
			this.MANA -= 25;
			ManaSlider.value -= 25;
			GameManager.currentMana = 25;
			Instantiate (manaObj, gameObject.transform.position, manaObj.rotation);
			if (ataqueMod == 1) {
				StartCoroutine (returnJastra (0, enemy));
			} 
			else if (ataqueMod == 2) {
				StartCoroutine (returnJastra (Inteligence + 10, enemy));
			} 
			else {
				StartCoroutine (returnJastra (Inteligence - 5, enemy));
			}
			enemy.GetComponent<Animator> ().SetTrigger ("ice");
		}

		if(((Input.GetKeyDown("3")) || GameManager.thirdAttack == "y") && (GameManager.whichTurn == 1) && this.MANA >= 40){
			GameManager.thirdAttack = "n";
			this.MANA -= 40;
			ManaSlider.value -= 40;
			GameManager.currentMana = 40;
			Instantiate (manaObj, gameObject.transform.position, manaObj.rotation);
			enemigos[0].GetComponent<Animator>().SetTrigger("iceSpecial");
			if (ataqueMod == 1) {
				StartCoroutine (returnJastra (0, enemy));
			} 
			else if (ataqueMod == 2) {
				StartCoroutine (returnJastra (Inteligence * 2, enemy));
			} 
			else {
				StartCoroutine (returnJastra (Inteligence + 5, enemy));
			}
				
		}
	}

	IEnumerator returnJastra(int damage, Transform enemy ){
		GameManager.currentDamage = damage;

		Transform enemigo = enemigos [0];
		Instantiate (dmgObj, enemigo.transform.position, dmgObj.rotation);
		enemy.gameObject.SendMessage ("ApplyDamage", damage);
		yield return new WaitForSeconds (0);
		if (GameManager.leocepAlive == "alive") {
			GameManager.whichTurn = 2;
		} 
		else {
			GameManager.whichTurn = 3;
		}
	}

	void ApplyHeal(int healAmmount){

		HPSlider.value += healAmmount;
		this.HP += healAmmount;

	}

	void ApplyDamage(int damage){

		HPSlider.value -= damage;
		this.HP -= damage;
	}


}
