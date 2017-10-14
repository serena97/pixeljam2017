using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject projectile;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode jumpKey = KeyCode.X;
    public KeyCode shootKey = KeyCode.Z;

    public int shootingInterval = 200;
    public float moveForce = 5;
    public float jumpForce = 10;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    private int shootingCooldown = 0;
    private bool canJump = true;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update () {

        float xVelocity = 0;
        float yVelocity = rigidBody.velocity.y;

        if (Input.GetKey(moveLeftKey)) {
            xVelocity -= moveForce;
        }
        if (Input.GetKey(moveRightKey)) {
            xVelocity += moveForce;
        }
        if (canJump && Input.GetKeyDown(jumpKey)) {
            yVelocity += jumpForce;
            canJump = false; // Can't jump again until we land.
        }

        if (xVelocity != 0) { // Only update the facing direction if we are moving.
            spriteRenderer.flipX = xVelocity < 0;
        }

        rigidBody.velocity = new Vector2(xVelocity, yVelocity);

        if (shootingCooldown <= 0 && Input.GetKey(shootKey)) {
            ShootProjectile(spriteRenderer.flipX ? Direction.Left : Direction.Right);
            shootingCooldown = shootingInterval;
        }

        shootingCooldown--;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        foreach(ContactPoint2D contactPoint in collision.contacts) {
            if(contactPoint.normal.y > 0) { // Is the normal of the collision pointing upward?
                canJump = true; // That means we hit the floor. Allow jumping again.
                break; // No need to continue iteration.
            }
        }
    }

    private void ShootProjectile(Direction direction) {
        Vector2 projectileOffset = (direction == Direction.Left ? Vector2.left : Vector2.right) * 0.5f;
        GameObject gameObject = Instantiate(this.projectile);
        gameObject.transform.position = (Vector2)transform.position + projectileOffset;
        Apple apple = gameObject.GetComponent<Apple>();
        apple.InitialiseVelocity(direction);
    }
}
