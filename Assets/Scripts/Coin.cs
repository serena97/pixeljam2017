﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public static Coin instance;

	// Use this for initialization
	void Start () {
		// update text of coin 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// if collider is entered by player then coin hides 	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject == Player.instance.gameObject) {
			gameObject.SetActive (false);
		}
	}
}
