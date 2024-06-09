using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{

    static GameScript instance;

    [Header("Game Objects")]
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Npc;

    [Header("Variables")]
    public float fadeTime;

    [Header("Booleans 1")]
    public bool isMainMenuActive = true;
    public bool isPlayerChangingScenes = false;
    public bool canPlayerControl = true;
    public bool hasPlayerObtainedNPCSword = false;

    [Header("Booleans 2")]
    public bool arePrefabsInstantiated = false;

    [Header("Positions")]
    public Vector3 playerSpawnLocation;
    public Vector3 enemySpawnLocation;
    public Vector3 npcSpawnLocation;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        //Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));
        //Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));
        //Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));
        //Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));
        //Instantiate(Enemy, enemySpawnLocation, Quaternion.Euler(0, 0, 0));

    }

    private void Update()
    {
        if (!isMainMenuActive && !arePrefabsInstantiated)
        {
            StartCoroutine(SpawnPrefabs());

            arePrefabsInstantiated = true;
        }
    }

    IEnumerator SpawnPrefabs()
    {
        yield return new WaitForSeconds(0.25f);

        Instantiate(Player, playerSpawnLocation, Quaternion.Euler(0, 0, 0));

        Instantiate(Npc, npcSpawnLocation, Quaternion.Euler(0, 0, 0));
    }

}
