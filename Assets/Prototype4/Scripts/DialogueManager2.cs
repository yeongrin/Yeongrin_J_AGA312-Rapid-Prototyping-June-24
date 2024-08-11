using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager2 : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialPanel;
    private Queue<string> sentences;

    public Animator anim;
    public GameObject spawn;
    public GameObject forces;
    public GameObject timer;
    public GameObject firing;

    [Header("Image")]
    public Sprite[] sprites;
    public Image image;

    void Start()
    {
        sentences = new Queue<string>();

        image.sprite = sprites[0];

    }

    void Update()
    {
        if (sentences.Count == 11)
        {
            image.sprite = sprites[1];

        }
        else if (sentences.Count == 9)
        {
            image.sprite = sprites[2];
        }
        else if (sentences.Count == 7)
        {
            image.sprite = sprites[3];
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
        spawn.gameObject.GetComponent<EnemySpawnP2>().enabled = true;
        timer.gameObject.GetComponent<Timer>().enabled = true;
        forces.gameObject.GetComponent<EnemySpawnP2>().enabled = true;
        firing.gameObject.GetComponent<FiringPoint>().enabled = true;
        dialPanel.SetActive(false);
    }

}
