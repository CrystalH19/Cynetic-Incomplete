using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public string gameStartScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    public void quitGame() { 
        Application.Quit();
    }
}
