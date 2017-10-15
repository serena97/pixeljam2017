using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance; // Singleton design pattern.

    public void SwitchScene(string nextScene, Direction direction)
    {
        if (direction == Direction.Left)
        {
            Player.instance.transform.position = new Vector2(
                Player.instance.transform.position.x + 16,
                Player.instance.transform.position.y
            );
        }
        if (direction == Direction.Right)
        {
            Player.instance.transform.position = new Vector2(
                Player.instance.transform.position.x - 16,
                Player.instance.transform.position.y
            );
        }

        SceneManager.LoadScene(nextScene);
    }

    void Start() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
