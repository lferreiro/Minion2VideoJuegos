using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static int whichTurn = 1;
	public static int currentDamage = 0;
	public static int currentHeal = 0;
	public static int currentMana = 0;

	public static string leocepAlive = "alive";
	public static string jastraAlive = "alive";

	public static string basicAttack = "n";
	public static string secondAttack = "n";
	public static string thirdAttack = "n";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (whichTurn == 1 && jastraAlive == "dead") {
			GameManager.whichTurn = 2;
		}

		if (whichTurn == 2 && leocepAlive == "dead") {
			GameManager.whichTurn = 1;
		}
		
	}
}
