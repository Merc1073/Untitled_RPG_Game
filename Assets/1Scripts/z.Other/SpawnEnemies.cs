using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    GameScript gScript;

    public GameObject enemy;

    public GameObject[] enemyPosition;

    private bool hasFinishedSpawningEnemies = false;

    private void Update()
    {
        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        if(gScript.npcDialogueOneEnded && !hasFinishedSpawningEnemies && !gScript.hasKill5CubeQuestFinished)
        {
            for(int i = 0; i < enemyPosition.Length; i++) 
            { 
                GameObject enemyClone = Instantiate(enemy, enemyPosition[i].transform.position, Quaternion.identity);
                enemyClone.name = "CaveEnemy";
            }

            hasFinishedSpawningEnemies = true;
        }
    }

}
