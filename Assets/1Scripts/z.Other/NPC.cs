using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{

    //public bool dialogueOneEnded = false;
    public bool dialogueTwoEnded = false;

    GameScript gScript;

    private void Update()
    {

        if(!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        if(gScript.npcDialogueOneEnded)
        {
            gScript.hasPlayerObtainedNPCSword = true;
            gScript.hasKill5CubeQuestStarted = true;

            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }

        if(dialogueTwoEnded)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }

        if(gScript.toDestroyNpc)
        {
            Destroy(gameObject);
        }

    }

}
