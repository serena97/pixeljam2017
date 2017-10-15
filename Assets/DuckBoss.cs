using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBoss : MonoBehaviour {

    public DuckMinion duckMinionPrefab;
    public int spawnInterval = 60;
    public int hitpoints = 100;
    private int spawnCooldown;
    private SpriteRenderer spriteRenderer;

    void CreateMinion()
    {
        DuckMinion minion = Instantiate<DuckMinion>(duckMinionPrefab);
        minion.behaviour = DuckMinionMode.Leftward;
        minion.transform.position = new Vector2(transform.position.x, -3.59f);
    }

	// Use this for initialization
	void Start () {
        spawnCooldown = spawnInterval;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if(--spawnCooldown <= 0)
        {
            spawnCooldown = spawnInterval;
            CreateMinion();
        }
        HandleFlicker();
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        Apple apple = collider.gameObject.GetComponent<Apple>();
        if (apple != null)
        {
            StartFlicker();
            hitpoints--;
            if (hitpoints <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collider.gameObject);
        }
    }
}
