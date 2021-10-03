using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isTalking = false;

    public void TriggerDialogue ()
    {
        if (!isTalking)
        {
            isTalking = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        } else
        {
            isTalking = FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
}
