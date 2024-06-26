using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;
    private bool paused;

    private void Start()
    {
        paused = false;
        pausePanel.SetActive(paused);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }

    public void Pause()
    {
        paused = !paused;
        pausePanel.SetActive(paused);
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        Time.timeScale = paused ? 0 : 1;
    }

}
