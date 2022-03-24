using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject player;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> dialogue;




    // Start is called before the first frame update
    private void Start()
    {
        dialogue = new Queue<string>();
    }

    public void startDialogue(string[] sentences)
    {
        dialogue.Clear();
        dialogueUI.SetActive(true);

        player.GetComponent<PlayerMovement_2D>().enabled = false;
        player.GetComponent<PlayerInteraction>().enabled = false;

        animator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach (string currentLine in sentences)
        {
            dialogue.Enqueue(currentLine);
        }
        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if (dialogue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string currentLine = dialogue.Dequeue();
        dialogueText.text = currentLine;
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);

        player.GetComponent<PlayerMovement_2D>().enabled = true;
        player.GetComponent<PlayerInteraction>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
