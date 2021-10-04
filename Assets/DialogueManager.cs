using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text promptText;
    public Text continueText;
    public Text nameText;
    public Text dialogueText;
    public RawImage characterImage;

    public Animator animator;

    //public int lastInterlude;

    Queue<string> sentences;
    bool waitText = false;
    void Start()
    {
        HidePrompt();
        continueText.enabled = false;
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
        if (!waitText)
        {
            continueText.enabled = false;
            if (sentences.Count == 0)
            {
                EndDialogue();
                return false;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            if (sentence[0] != '(')
            {
                waitText = true;
                StartCoroutine(TypeSentence(sentence));
                return true;
            }
            else
            {
                waitText = true;
                StartCoroutine(ShowMessage(sentence, 2));
                return true;
            }
        }
        return true;
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        promptText.text = message;
        promptText.enabled = true;
        yield return new WaitForSeconds(delay);
        //yield return null;
        promptText.enabled = false;
        promptText.text = "Press \"E\"";
        waitText = false;
        continueText.enabled = true;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.02f);
        }
        waitText = false;
        continueText.enabled = true;
    }

    void EndDialogue ()
    {
        ShowPrompt();
        animator.SetBool("IsOpen", false);

        //if (SceneManager.GetActiveScene().buildIndex == lastInterlude)
        //{
        //    FindObjectOfType<LevelLoader>().specialLoadNextLevel();
        //}

        if (nameText.text == "DOUBLE" && waitText == false)
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
        }

        if(nameText.text == "NURSE" && SceneManager.GetActiveScene().buildIndex == 15 && waitText == false)
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel(); 
        }
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
