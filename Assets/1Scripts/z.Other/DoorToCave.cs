using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToCave : MonoBehaviour
{

    GameScript gScript;

    private void Update()
    {
        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        if(gScript.npcDialogueOneEnded)
        {
            gScript.isCaveDoorOpen = true;
            Destroy(gameObject);
        }
    }

}
