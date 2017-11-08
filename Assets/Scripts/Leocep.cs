using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leocep : MonoBehaviour {

	public int HP = 100;
	public int MANA = 100;
	public int Inteligence = 10;
	public int Strenght = 30;
	public int magicResist = 15;
	public int strResit = 15;


	public List<Transform> enemigos;
	public List<Transform> aliados;

	public Transform dmgObj;
	public Transform manaObj;

	public Transform healObj;

	public Slider HPSlider;
	public Slider ManaSlider;
	public Text NameText;
	public GameObject HPMANAPanel;

	// Use this for initialization
	void Start () {

		NameText.text = "Leocep";
		
	}
	
	// Update is called once per frame
	void Update () {

		if (HP <= 0) {
			Destroy (HPMANAPanel);
			Destroy (gameObject);
			GameManager.leocepAlive = "dead";
		}

		aliados.RemoveAll (enemigo => enemigo == null);
		Transform enemy = enemigos [0];
		int ataqueMod = Random.Range (0, 10);

		if (((Input.GetKeyDown ("1")) || GameManager.basicAttack == "y" )&& (GameManager.whichTurn == 2)) {
			
			GameManager.currentMana = 0;
			GameManager.basicAttack = "n";
			Instantiate (manaObj, gameObject.transform.position, manaObj.rotation);
			enemy.GetComponent<Animator>().SetTrigger("slash");
			if (ataqueMod == 1) {
				StartCoroutine (returnLeocep (0, enemy));
			} 
			else if (ataqueMod == 2) {
				StartCoroutine (returnLeocep (35, enemy));
			} 
			else {
				StartCoroutine (returnLeocep (20, enemy));
			}
				
			GameManager.whichTurn = 3;

		}

		if (((Input.GetKeyDown ("2")) || GameManager.secondAttack == "y") && (GameManager.whichTurn == 2) && MANA >= 20 && GameManager.jastraAlive == "alive" ) {
			GameManager.secondAttack = "n";
			Transform aliado = aliados [0];
			this.MANA = this.MANA - 20;
			ManaSlider.value -= 20;
			GameManager.currentMana = 20;
			Instantiate (manaObj, gameObject.transform.position, manaObj.rotation);
			StartCoroutine (healAlly (25, aliado));
			GameManager.whichTurn = 3;

		}

		if (((Input.GetKeyDown ("3")) || GameManager.thirdAttack == "y" )&& (GameManager.whichTurn == 2) && MANA >= 40) {
			GameManager.thirdAttack = "n";
			enemy.GetComponent<Animator>().SetTrigger("slashSpecial");
			this.MANA = this.MANA - 40;
			ManaSlider.value -= 40;
			GameManager.currentMana = 40;
			Instantiate (manaObj, gameObject.transform.position, manaObj.rotation);
			if (ataqueMod == 1){
				StartCoroutine (returnLeocep (0, enemy));
			}
			else if(ataqueMod == 2) {
				StartCoroutine (returnLeocep (75, enemy));
			}
			else{
				StartCoroutine (returnLeocep (50, enemy));
			}
				
			GameManager.whichTurn = 3;

		}
	}

	IEnumerator returnLeocep(int dmg, Transform enemy){

		GameManager.currentDamage = dmg;
		Transform Enemy = enemigos [0].transform;
		Instantiate (dmgObj, Enemy.position, dmgObj.rotation);
		enemy.gameObject.SendMessage ("ApplyDamage", dmg);
		yield return new WaitForSeconds(0);


	}

	IEnumerator healAlly(int healAmmount, Transform ally){
		GameManager.currentHeal = healAmmount;
		yield return new WaitForSeconds(0);
		ally.GetComponent<Animator>().SetTrigger("heal");
		ally.gameObject.SendMessage ("ApplyHeal", healAmmount);
		Instantiate (healObj, ally.transform.position, healObj.rotation);
	}

	void ApplyDamage(int damage){

		HPSlider.value -= damage;
		this.HP -= damage;
	}



}
