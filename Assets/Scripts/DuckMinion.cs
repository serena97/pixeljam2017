using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMinion : MonoBehaviour {

	public float speed = 1.0f;
	Rigidbody2D rigidBody;
	SpriteRenderer spriteRenderer;
	Direction direction = Direction.Right;
	int timer = 200;

	public int hitpoint = 10;
	public int damage = 10;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer--;
		if (timer <= 0) { 
			direction = direction == Direction.Left ? Direction.Right : Direction.Left;
			timer = 200;
		}
		spriteRenderer.flipX = direction == Direction.Right;
		Vector2 newVelocity = new Vector2 (direction == Direction.Left ? -speed : speed, rigidBody.velocity.y);
		rigidBody.velocity = newVelocity;

		//if hit with apple, health -- whatever
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject collisionObject = collider.gameObject;
		Apple apple = collisionObject.GetComponent<Apple> ();
		hitpoint--;
		if (apple != null) { // this is an apple
			if (hitpoint <= 0) {
				Destroy (gameObject);
				//sho 
			} else {
				Destroy (collisionObject); //so that apple will shoot pass vase
			}

		}
	}


}
