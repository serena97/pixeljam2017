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
        GameManager gameManager = GameManager.GetInstance();
        if(collision.gameObject == gameManager.player.gameObject && nextScene != "") {
            gameManager.SwitchScene(nextScene, direction);
        }
    }
}
