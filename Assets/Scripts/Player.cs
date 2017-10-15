using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance; // Singleton design pattern.

    public GameObject projectile;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode jumpKey = KeyCode.X;
    public KeyCode shootKey = KeyCode.Z;

    public int shootingInterval = 200;
    public float moveForce = 5;
    public float jumpForce = 10;

    public int hitpoint = 10;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private int shootingCooldown = 0;
    private bool canJump = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void UseItem()
    {
        Item selectedItem = InventoryDisplay.instance.CurrentItem();

        switch (selectedItem)
        {
            case Item.Apple:
                ShootProjectile(spriteRenderer.flipX ? Direction.Right : Direction.Left);
                break;
        }
    }

    void Update()
    {
        HandleFlicker();

        float xVelocity = 0;
        float yVelocity = rigidBody.velocity.y;

        if (Input.GetKey(moveLeftKey))
        {
            xVelocity -= moveForce;
        }
        if (Input.GetKey(moveRightKey))
        {
            xVelocity += moveForce;
        }
        if (canJump && Input.GetKey(jumpKey))
        {
            yVelocity += jumpForce;
            canJump = false; // Can't jump again until we land.
        }

        if (xVelocity != 0)
        { // Only update the facing direction if we are moving.
            spriteRenderer.flipX = xVelocity > 0;
            animator.SetTrigger("BeginRun");
        }
        else
        {
            animator.SetTrigger("EndRun");
        }

        rigidBody.velocity = new Vector2(xVelocity, yVelocity);

        if (Input.GetKeyDown(jumpKey) && Door.activeDoor && !Door.activeDoor.locked)
        {
            Door.activeDoor.Enter();
        }

        if (shootingCooldown <= 0 && Input.GetKey(shootKey))
        {
            shootingCooldown = shootingInterval;
            UseItem();
        }

        shootingCooldown--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            if (contactPoint.normal.y > 0)
            { // Is the normal of the collision pointing upward?
                canJump = true; // That means we hit the floor. Allow jumping again.
                break; // No need to continue iteration.
            }
        }

        GameObject collisionObj = collision.gameObject;
        DuckMinion enemy = collisionObj.GetComponent<DuckMinion>();

        if (enemy != null)
        {
            StartFlicker();
            HitpointsBar.instance.Damage(1);
            hitpoint--;
            if (hitpoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void ShootProjectile(Direction direction)
    {
        Vector2 projectileOffset = (direction == Direction.Left ? Vector2.left : Vector2.right) * 0.5f;
        GameObject gameObject = Instantiate(this.projectile);
        gameObject.transform.position = (Vector2)transform.position + projectileOffset;
        Apple apple = gameObject.GetComponent<Apple>();
        apple.InitialiseVelocity(direction);
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
        if (flickerCurrentCount > 0)
        {
            if (flickerToggleDelayCurrent > 0)
            {
                flickerToggleDelayCurrent--;
            }
            else
            {
                flickerToggleDelayCurrent = flickerToggleDelayMax;
                flickerCurrentCount--;

                if (flickerCurrentCount <= 0)
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