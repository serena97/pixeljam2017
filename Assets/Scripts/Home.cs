using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HouseState {
    Inside, Outside
}

public class Home : MonoBehaviour {

    public Sprite outerHouse;
    public Sprite innerHouse;
    public GameObject door;
    public GameObject leftWall;
    public GameObject rightWall;

    private BoxCollider2D leftCollider;
    private BoxCollider2D rightCollider;

    private HouseState houseState = HouseState.Outside;
    private bool doorActive = false;

    private SpriteRenderer spriteRenderer;

    public void EnterHouse() {
        houseState = HouseState.Inside;
        spriteRenderer.sprite = innerHouse;
        leftCollider.enabled = true;
        rightCollider.enabled = true;
    }

    public void LeaveHouse() {
        houseState = HouseState.Outside;
        spriteRenderer.sprite = outerHouse;
        leftCollider.enabled = false;
        rightCollider.enabled = false;
    }

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        leftCollider = leftWall.GetComponent<BoxCollider2D>();
        rightCollider = rightWall.GetComponent<BoxCollider2D>();
        LeaveHouse();
        doorActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject == Player.instance.gameObject) {
            doorActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject == Player.instance.gameObject) {
            doorActive = false;
        }
    }

    // Update is called once per frame
    void Update () {
		if(doorActive && Input.GetKeyDown(KeyCode.Z)) {
            if(houseState == HouseState.Inside) {
                LeaveHouse();
            }
            else {
                EnterHouse();
            }
        }
	}
}
