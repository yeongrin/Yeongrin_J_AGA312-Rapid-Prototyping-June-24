using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public static bool optioned = false;
    public GameObject optionPanel;

    [Header("Fade")]
    GameObject SplashObj;
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    Image image;

    public void StartButton()
    {
        StartCoroutine(Fade());
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("Main");
    }

    IEnumerator Fade()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Prototype 1");
        }


    void Update()
    {

    }

    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Option()
    {
        optionPanel.SetActive(true);
        optioned = true;
    }

    public void OptionFalse()
    {
        optionPanel.SetActive(false);
        optioned = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
