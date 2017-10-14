using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager instance; // Singleton design pattern.

    public Player player;

    public static GameManager GetInstance() {
        return instance;
    }

    public void SwitchScene(string nextScene, Direction direction)
    {
        if (direction == Direction.Left)
        {
            player.transform.position = new Vector2(
                player.transform.position.x + 18,
                player.transform.position.y
            );
        }
        if (direction == Direction.Right)
        {
            player.transform.position = new Vector2(
                player.transform.position.x - 18,
                player.transform.position.y
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
