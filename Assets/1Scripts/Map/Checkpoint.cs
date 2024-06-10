using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    GameScript gScript;

    private void Update()
    {
        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gScript.gs_Checkpoint = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gScript.SaveGameData();
        }
    }

}
