using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{

    GameScript gScript;

    public bool isInsideTrigger = false;

    private void Update()
    {

        if(!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }


        if(!gScript.npcDialogueOneEnded && !gScript.hasKill5CubeQuestFinished)
        {
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }

        if (gScript.npcDialogueOneEnded && !gScript.hasKill5CubeQuestFinished)
        {
            gScript.hasPlayerObtainedNPCSword = true;
            gScript.hasKill5CubeQuestStarted = true;

            gScript.npcDialogueOneEnded = true;

            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }

        if(gScript.hasKill5CubeQuestFinished && !gScript.npcDialogueThreeEnded)
        {
            gScript.npcDialogueTwoEnded = true;

            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }

        if(gScript.npcDialogueThreeEnded && gScript.hasKill5CubeQuestFinished)
        {
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }

        if (gScript.toDestroyNpc)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInsideTrigger = false;

    }

}
