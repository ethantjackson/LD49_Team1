using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public LevelLoader levelLoader;
    public Dialogue dialogue;
    public bool isTalking = false;
    public bool visited = false;
    public bool lastDialogue = false;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }
    private void Update()
    {
        if (!visited) { 
	        if (isTalking) {
                Debug.Log(dialogue.name);
                levelLoader.charactersLeft.Remove(dialogue.name);
                visited = true;
	        }
	    }
        
    }

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
