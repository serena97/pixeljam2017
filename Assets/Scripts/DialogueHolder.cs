using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string[] dialogue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameManager gameManager = GameManager.GetInstance();
		if (collider.gameObject == gameManager.player.gameObject) {
			DialogueManager.instance.Show (dialogue);
		}
	}
	void OnTriggerExit2D(Collider2D collider) {
		DialogueManager.instance.Hide ();
	}
}
