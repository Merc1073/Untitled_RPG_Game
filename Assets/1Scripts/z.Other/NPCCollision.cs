using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollision : MonoBehaviour
{

    GameScript gScript;
    //DialogueManager dialManager;

    [SerializeField]

    private void Update()
    {
        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        //if (!dialManager)
        //{
        //    dialManager = FindObjectOfType<DialogueManager>();
        //}

        if(transform.parent.gameObject.GetComponent<NPC>().isInsideTrigger)
        {
            if(Input.GetMouseButtonDown(0) && !gScript.isDialogueActive)
            {
                Debug.Log("Dialogue triggered");
                GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }

        if(!transform.parent.gameObject.GetComponent<NPC>().isInsideTrigger)
        {
            FindObjectOfType<DialogueManager>().InterruptDialogue();
        }


    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player") && !gScript.hasPlayerObtainedNPCSword && !GetComponentInParent<NPC>().dialogueOneEnded)
    //    {
    //        GetComponent<DialogueTrigger>().TriggerDialogue();
    //    }

    //    if (other.gameObject.CompareTag("Player") && !gScript.hasPlayerObtainedNPCSword && GetComponentInParent<NPC>().dialogueOneEnded)
    //    {
    //        GetComponent<DialogueTrigger>().TriggerDialogue();
    //    }

    //    if (other.gameObject.CompareTag("Player") && Input.GetMouseButtonDown(0))
    //    {
    //        GetComponent<DialogueTrigger>().TriggerDialogue();
    //    }
    //}

}
