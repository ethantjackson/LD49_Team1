using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;

    DialogueTrigger dialogueTrigger = null;
    public DialogueManager dialogueManager;

    // Update is called once per frame
    void Update()
    {
        if (dialogueTrigger == null || dialogueTrigger.isTalking == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        if (Input.GetKeyDown(KeyCode.E) && dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue();
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            dialogueManager.ShowPrompt();
            dialogueTrigger = other.GetComponent<DialogueTrigger>();
        }
        if (other.tag == "ExitDoor") {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
	    }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            dialogueManager.HidePrompt();
            dialogueTrigger = null;
        }
    }
}
