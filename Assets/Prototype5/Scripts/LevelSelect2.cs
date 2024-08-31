using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect2 : MonoBehaviour
{
    public GameObject levelSelectPanel;
    private bool paused;

    void Start()
    {
        paused = false;
        levelSelectPanel.SetActive(paused);
    }

    // Update is called once per frame
    void Update()
    {

    }

   public void OpenPanel()
    {
        paused = !paused;
        levelSelectPanel.SetActive(paused);
    }

    public void ClosePanel()
    {
        paused = false;
        levelSelectPanel.SetActive(paused);
    }
}
