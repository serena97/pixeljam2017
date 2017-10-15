using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	private BoxCollider2D boxCollider2D;

	// Use this for initialization
	void Start () {
		boxCollider2D = GetComponent<BoxCollider2D> ();
		// update text of coin 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// if collider is entered by player then coin hides 	
	void OnCollisionEnter2D(Collision2D collider) {
		Debug.Log ("coin trigger");
		Debug.Log ("(collider.gameObject" + collider.gameObject);
		if (collider.gameObject == Player.instance.gameObject) {
			Debug.Log ("hello");
			CoinManager.instance.coinCounter++;
			boxCollider2D.enabled = false;
			Debug.Log ("destroy");
			Destroy (gameObject);
		}

	}
}
