using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIPlayButton : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.MoveToNextLevel();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestarGame()
    {
        GameManager.Instance.RestartGame();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
