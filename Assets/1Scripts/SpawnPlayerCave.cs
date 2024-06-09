using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerCave : MonoBehaviour
{
    private GameObject player;
    bool playerFound = false;

    bool playerSpawned = false;

    private void Update()
    {

        if (!player && !playerFound)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerFound = true;
        }

        if (player && !playerSpawned)
        {
            player.gameObject.transform.position = transform.position;
            playerSpawned = true;
        }

    }
}
