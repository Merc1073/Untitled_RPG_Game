using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject Player;

    [Header("Positions")]
    public Vector3 playerMenuSpawn;

    private void Start()
    {
        Instantiate(Player, playerMenuSpawn, Quaternion.Euler(0, 0, 0));
    }

}
