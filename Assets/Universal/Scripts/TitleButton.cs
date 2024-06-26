using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    public Image splashImage;
    public Sprite image;

    public void OnMouseEnter()
    {

        splashImage.sprite = image;
        splashImage.enabled = true;
    }

    public void OnMouseExit()
    {
        splashImage.enabled = false;
    }
}
