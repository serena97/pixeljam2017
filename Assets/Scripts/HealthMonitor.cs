using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMonitor : MonoBehaviour {

	public static HealthMonitor instance;
	private Text healthText;
	public int healthCounter;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		healthText = GetComponent<Text> ();
		healthText.text = "health: "+ healthCounter.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = "health: "+ healthCounter.ToString();
	}
}
