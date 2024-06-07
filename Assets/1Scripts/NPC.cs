using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public bool dialogueOneEnded = false;
    public bool dialogueTwoEnded = false;

    private void Update()
    {

        if(dialogueOneEnded)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }

        if(dialogueTwoEnded)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }

}
