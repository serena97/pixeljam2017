using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMinion : MonoBehaviour {

	public float speed = 0.5f;
	Rigidbody2D rigidBody;
	SpriteRenderer spriteRenderer;
	Direction direction = Direction.Right;
	int timer = 200;

	public Transform player;

	public int hitpoint = 10;
	public int damage = 10;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		player = GameObject.Find("Player").transform;
	}

	// Update is called once per frame
	void Update () {

		if (player != null) { 
			Vector3 direction = player.position - transform.position;
			transform.position += (player.position - transform.position).normalized * speed * Time.deltaTime;
		} else {
			patrol ();
		}
	
        //if hit with apple, health -- whatever
        HandleFlicker();
	}

	void patrol() {
		timer--;
		if (timer <= 0) { 
			direction = direction == Direction.Left ? Direction.Right : Direction.Left;
			timer = 200;
		}

		spriteRenderer.flipX = direction == Direction.Right;
		Vector2 newVelocity = new Vector2 (direction == Direction.Left ? -speed : speed, rigidBody.velocity.y);
		rigidBody.velocity = newVelocity;
	}


	void OnTriggerEnter2D(Collider2D collider) {
		GameObject collisionObject = collider.gameObject;
		Apple apple = collisionObject.GetComponent<Apple> ();
		hitpoint--;
        StartFlicker();
		if (apple != null) { // this is an apple
			if (hitpoint <= 0) {
				Destroy (gameObject);
				//sho 
			} else {
				Destroy (collisionObject); //so that apple will shoot pass vase
			}

		}
	}

    private int flickerMaxCount = 10;
    private int flickerCurrentCount = 0;
    private int flickerToggleDelayMax = 1;
    private int flickerToggleDelayCurrent = 0;

    public void StartFlicker()
    {
        flickerCurrentCount = flickerMaxCount;
    }

    public void HandleFlicker()
    {
        if(flickerCurrentCount > 0)
        {
            if(flickerToggleDelayCurrent > 0)
            {
                flickerToggleDelayCurrent--;
            }
            else
            {
                flickerToggleDelayCurrent = flickerToggleDelayMax;
                flickerCurrentCount--;

                if(flickerCurrentCount <= 0)
                {
                    spriteRenderer.enabled = true;
                }
                else
                {
                    spriteRenderer.enabled = flickerCurrentCount % 2 == 0;
                }
            }
        }
    }


}
