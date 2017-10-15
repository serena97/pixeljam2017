using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

	private Text coinText;
	public int coinCounter; 

	// Use this for initialization
	void Start () {
		coinText = GetComponent<Text> ();
		coinText.text = coinCounter.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	}

}
