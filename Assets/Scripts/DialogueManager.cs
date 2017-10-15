using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public static DialogueManager instance;
	public string[] message;
	public Text messageDisplay;
	private int currentMessageIndex = 0;

	void Start() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		Hide ();
	}
	public void Show(string[] message) {
		this.message = message;
		gameObject.SetActive (true);
		currentMessageIndex = 0;
		ShowMessage ();
	}
	public void Hide() {
		gameObject.SetActive (false);
	}
	private void ShowMessage() {
		messageDisplay.text = message [currentMessageIndex];
	}
	private void NextMessage() {
		currentMessageIndex++;
		if (currentMessageIndex >= message.Length) {
			Hide ();
		} else {
			ShowMessage ();
		}
	}
	void Update() {
		if (Input.GetKeyDown (KeyCode.Z)) {
			NextMessage ();
		}
	}
}
