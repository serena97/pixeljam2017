using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject == Player.instance.gameObject) {
            InventoryDisplay.instance.PickupItem(Item.Key);
            Destroy(gameObject);
        }
    }
}
