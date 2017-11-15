using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlacement : MonoBehaviour {

	public GameObject TrackObject;
	public Vector3 Offset;


	// Update is called once per frame
	void Update () {
		gameObject.transform.position = Camera.main.WorldToScreenPoint(TrackObject.transform.position) + Offset;
	}
}
