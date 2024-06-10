using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    GameScript gScript;

    public GameObject player;

    private void Update()
    {
        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        if(gScript.gs_CurrentPlayer)
        {
            player = gScript.gs_CurrentPlayer;
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
        }
    }

}
