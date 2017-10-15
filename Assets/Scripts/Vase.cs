using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour {

	public Sprite shatteredVase;
	public Sprite unshatteredVase;
	public GameObject coin; //coin prefab 
	private BoxCollider2D boxCollider2D;
	private SpriteRenderer spriteRenderer;

	public int hitpoint = 10;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		boxCollider2D = GetComponent<BoxCollider2D> ();
	}


	
	// Update is called once per frame
	void Update () {
		
	}

	void Break() {
		spriteRenderer.sprite = shatteredVase;
		createCoin ();
	}

	void createCoin() {
		GameObject newCoin = Instantiate (coin);
		newCoin.transform.position = this.transform.position;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject collisionObject = collider.gameObject;
		Apple apple = collisionObject.GetComponent<Apple> ();
		hitpoint--;
		if (apple != null) { // this is an apple
			//trigger pot to break
			if (hitpoint <= 0) {
				Break ();
				boxCollider2D.enabled = false;
				//sho 
			} else {
				Destroy (collisionObject); //so that apple will shoot pass vase
			}

		}
	}
		
}
