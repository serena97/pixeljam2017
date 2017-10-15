using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//
// The purpouse of this script is to handle scene switching
// when the player reaches the edge of the screen.
// 

public class Boundry : MonoBehaviour {

    public string nextScene = "";
    public Direction direction;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject == Player.instance.gameObject && nextScene != "") {
            GameManager.instance.SwitchScene(nextScene, direction);
        }
    }
}
