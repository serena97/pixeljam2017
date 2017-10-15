using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMinion : MonoBehaviour {

	public float speed = 1.0f;
	Rigidbody2D rigidBody;
	SpriteRenderer spriteRenderer;
	Direction direction = Direction.Right;
	int timer = 200;

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
	}
}
