using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text promptText;
    public Text nameText;
    public Text dialogueText;
    public RawImage characterImage;

    public Animator animator;

    Queue<string> sentences;
    void Start()
    {
        HidePrompt();
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        HidePrompt();
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        characterImage.texture = dialogue.characterImage;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public bool DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return false;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        return true;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.02f);
        }
    }

    void EndDialogue ()
    {
        ShowPrompt();
        animator.SetBool("IsOpen", false);
    }

    public void ShowPrompt ()
    {
        promptText.enabled = true;
    }
    public void HidePrompt ()
    {
        promptText.enabled = false;
    }
}
