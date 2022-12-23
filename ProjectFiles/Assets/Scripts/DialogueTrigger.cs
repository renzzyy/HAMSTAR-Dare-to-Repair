using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] new private Collider2D collider;
    [SerializeField] private GameObject dialogueBox;
    
   
    private void OnTriggerEnter2D(Collider2D col) 
    {
       if (col.CompareTag("Player")) 
       {
            TriggerDialogue();
            collider.enabled = false;
       }
    }

    public void TriggerDialogue() 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
