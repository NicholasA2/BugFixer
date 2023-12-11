using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnGameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.Instance.score = 0;
    }

    public void OnGameStop()
    {
        Application.Quit();
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.score = 0;
    }
}
