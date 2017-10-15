using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public static Door activeDoor;
    public Sprite unlockedDoorGraphic;
    public Sprite lockedDoorGraphic;
    public string destination = "";
    public bool locked;

    private SpriteRenderer spriteRenderer;

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
            activeDoor = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            if(activeDoor == this)
            {
                activeDoor = null;
            }
        }
    }

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(locked)
        {
            Lock();
        }
        else
        {
            Unlock();
        }
	}

    public void Enter() {
        SceneManager.LoadScene(destination);
	}
}
