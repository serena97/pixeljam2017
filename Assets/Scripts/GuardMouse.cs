using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardMouse : MonoBehaviour {

	public Text notInvited;
	private Rigidbody2D rb;

	//1. when mouse and fox distance is 5, the mouse says: "sorry, you're not invited to the feast"
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		// wait for 5 seconds
		notInvited.text = "Let's see...";
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
