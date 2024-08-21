using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager5 : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialPanel;
    private Queue<string> sentences;

    public Animator anim;

    public float shakeStrength;
    public float moveTweenTime = 0f;

    [Header("Image")]
    public Sprite[] sprites;
    public Image image;

    IEnumerator coroutine;

    void Start()
    {
        sentences = new Queue<string>();
        //image.sprite = sprites[0];

    }

    void Update()
    {
        if (sentences.Count == 15)
        {
            
        }
        else if (sentences.Count == 13)
        {
           
        }
       
    }

    public void StartDialogue(Dialogue dialogue)
    {

        anim.SetBool("isOpen", true);
        Debug.Log("Starting conversation with" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(Typing(sentence));
    }

    IEnumerator Typing(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End");
    }

    public void DialOver()
    {
        anim.SetBool("isOpen", false);
        dialPanel.SetActive(false);
    }

}
