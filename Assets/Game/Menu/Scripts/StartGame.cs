using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public GameObject imageStartGame;
    public GameObject canvas;

    public void StarGame(string sceneName)
    {
        imageStartGame.SetActive(true);
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation laodScene = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitUntil(()=> laodScene.isDone);
        canvas.SetActive(false);
    }
}
