using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

	public static CoinManager instance;
	private Text coinText;
	public int coinCounter; 

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		coinText = GetComponent<Text> ();
		coinText.text = "coins: "+ coinCounter.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		coinText.text = "coins: "+ coinCounter.ToString();
	}

}
