using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidad : MonoBehaviour {

	public string nombre;

	public bool esDeFuerza;

	public int damage;

	public int costoMana;

	public bool isSingleTarget;

	public bool isHeal;

	public List<Personaje> objetivos;

	public string trigger;

	public float animationDuration;

	public int precision;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
