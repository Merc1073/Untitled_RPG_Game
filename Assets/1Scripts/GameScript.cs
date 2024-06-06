using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject Player;
    public GameObject Enemy;

    [Header("Positions")]
    public Vector3 playerSpawnLocation;
    public Vector3 enemySpawnLocation;

    private void Start()
    {
        Instantiate(Player, playerSpawnLocation, Quaternion.Euler(0, 0, 0));

        Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));
        Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));
        Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));
        Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));
        Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));
    }

}
