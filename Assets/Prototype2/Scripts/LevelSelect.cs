using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameEndingPanel;

    public void Root()
    {
        SceneManager.LoadScene("Prototype 2");
    }

    public void Trunk()
    {
        SceneManager.LoadScene("Prototype2-2");
    }

    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameEndingPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void Title()
    {
        SceneManager.LoadScene("Level2TitleScene");
    }
}
