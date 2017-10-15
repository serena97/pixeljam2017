using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public Sprite unlockedDoorGraphic;
    public Sprite lockedDoorGraphic;
    public string destination = "";
    public bool locked;

    private SpriteRenderer spriteRenderer;
    private bool doorActive = false;

    public void Lock()
    {
        spriteRenderer.sprite = lockedDoorGraphic;
        locked = true;
    }

    public void Unlock()
    {

        spriteRenderer.sprite = unlockedDoorGraphic;
        locked = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            doorActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            doorActive = false;
        }
    }

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!locked && doorActive && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(destination);
        }
	}
}
