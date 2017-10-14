using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    Left, Right
}

public class Apple : MonoBehaviour {
    
    public float speed = 5.0f;

    private Rigidbody2D rigidBody;

    public void InitialiseVelocity(Direction direction) {
        if (direction == Direction.Right) {
            rigidBody.velocity = Vector2.right * speed;
        }
        else {
            rigidBody.velocity = Vector2.left * speed;
        }
    }

    // Use this for initialization
    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { 
        if(Utilities.Offscreen(transform.position)) {
            Destroy(gameObject);
        }
    }
}
