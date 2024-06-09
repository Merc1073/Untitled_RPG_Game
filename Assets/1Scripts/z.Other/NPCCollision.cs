using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollision : MonoBehaviour
{

    GameScript gScript;
    DialogueManager dialManager;

    [SerializeField]
    private bool insideTrigger = false;

    private void Update()
    {
        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        if(!dialManager)
        {
            dialManager = FindObjectOfType<DialogueManager>();
        }


        if(insideTrigger)
        {
            if(Input.GetMouseButtonDown(0) && !dialManager.isDialogueActive)
            {
                GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }

        else
        {
            FindObjectOfType<DialogueManager>().InterruptDialogue();
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player") && !gScript.hasPlayerObtainedNPCSword && !GetComponentInParent<NPC>().dialogueOneEnded)
        //{
        //    GetComponent<DialogueTrigger>().TriggerDialogue();
        //}

        //if(other.gameObject.CompareTag("Player") && !gScript.hasPlayerObtainedNPCSword && GetComponentInParent<NPC>().dialogueOneEnded)
        //{
        //    GetComponent<DialogueTrigger>().TriggerDialogue();
        //}

        //if (other.gameObject.CompareTag("Player") && Input.GetMouseButtonDown(0))
        //{
        //    GetComponent<DialogueTrigger>().TriggerDialogue();
        //}
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            insideTrigger = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            insideTrigger = false;
        }
    }

}
