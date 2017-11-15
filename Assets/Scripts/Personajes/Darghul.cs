/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darghul : MonoBehaviour {

	public int HP = 200;
	public int MANA = 100;
	public int Inteligence = 30;
	public int Strenght = 30;
	public int magicResist = 20;
	public int strResist = 20;

	public List<Transform> Enemigos;

	static Animator animator;

	public Transform dmgObj;
	public Transform manaObj;

	public Slider HPSlider;
	public Text NameText; 
	public GameObject HPMANAPanel;

	public bool alreadyAttacked = false;

	// Use this for initialization
	void Start () {
		
		NameText.text = "Darghul";
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0) {
			GameManager.darghulAlive = "dead";
			GameManager.whichTurn = 4;
			Destroy (HPMANAPanel);
			Destroy (gameObject);
		}
		if (GameManager.leocepAlive == "dead" && GameManager.jastraAlive == "dead") {
			GameManager.whichTurn = 5;
			Destroy (HPMANAPanel);
		} 
		else {
			Enemigos.RemoveAll (enemigo => enemigo == null);
			Transform whichToAttack = Enemigos [Random.Range (0, Enemigos.Count)].transform;
			int whichAttack = (Random.Range (1, 3));
			if ((GameManager.whichTurn == 3) && !alreadyAttacked) {
				if (whichAttack == 1) {
					StartCoroutine (normalAttack (whichToAttack));
				} 
				else if (!alreadyAttacked){
					StartCoroutine (specialAttack ());
				}


			}
		}

	}

	IEnumerator normalAttack(Transform whichToAttack){
		alreadyAttacked = true;
		yield return new WaitForSeconds (1);
		ControladorPelea.currentDamage = 40;
		whichToAttack.GetComponent<Animator>().SetTrigger("ignite1");
		Instantiate (dmgObj, whichToAttack.position , dmgObj.rotation);
		whichToAttack.SendMessage ("ApplyDamage", 40);
		GameManager.whichTurn = 1;
		alreadyAttacked = false;
	}

	IEnumerator specialAttack(){
		alreadyAttacked = true;
		yield return new WaitForSeconds (1);
		ControladorPelea.currentDamage = 25;
		foreach (var enemigo in Enemigos) {
			enemigo.GetComponent<Animator> ().SetTrigger ("ignite2");
			Instantiate (dmgObj, enemigo.position, dmgObj.rotation);
			enemigo.SendMessage ("ApplyDamage", 25);
			GameManager.whichTurn = 1;
			alreadyAttacked = false;
		}
	}

	void ApplyDamage(int damage){

			HPSlider.value -= damage;
			this.HP -= damage;
	}


}*/
