using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public static GameMenu instance;
    public GameObject canvasGame;
    public int enemiesAlive = 3;

    private void Start()
    {
        instance = this;
        enemiesAlive = 3;
    }

    private void Update()
    {
        if (GameMenu.instance.enemiesAlive <= 0)
        {
            canvasGame.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
