using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Level2Dialogue : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialPanel;
    private Queue<string> sentences;

    public Animator anim;

    public PlayerController5 player;
    IEnumerator coroutine;

    void Start()
    {
        sentences = new Queue<string>();

    }

    void Update()
    {

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

        player.enabled = true;
       
    }
}
