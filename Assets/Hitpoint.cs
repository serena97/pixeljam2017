using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoint : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    public void Show()
    {
        flickerCurrentCount = 0;
        flickerToggleDelayCurrent = 0;
        spriteRenderer.enabled = true;
    }

    public void Hide()
    {
        StartFlicker();
    }

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleFlicker();
    }

    private int flickerMaxCount = 5;
    private int flickerCurrentCount = 0;
    private int flickerToggleDelayMax = 3;
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
                    Destroy(gameObject);
                }
                else
                {
                    spriteRenderer.enabled = flickerCurrentCount % 2 == 0;
                }
            }
        }
    }
}
