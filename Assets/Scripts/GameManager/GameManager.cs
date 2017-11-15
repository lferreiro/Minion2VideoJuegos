using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static int whichTurn = 1;


	public static string leocepAlive = "alive";
	public static string jastraAlive = "alive";
	public static string darghulAlive = "alive";

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
		if (darghulAlive == "dead"){
			GameManager.whichTurn = 4;
			Debug.Log("Victory");
		}

		if (whichTurn == 5) {
			Debug.Log ("Defeat");
			GetComponent<Renderer> ().sortingOrder = 20;
			gameObject.transform.position = new Vector3 (0, 0, 0);
		}
		
	}
}
