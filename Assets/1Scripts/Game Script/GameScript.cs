using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{

    static GameScript instance;

    [Header("Game Objects")]
    public GameObject player;
    GameObject currentPlayer;
    public GameObject enemy;
    public GameObject npc;

    [Header("Player Variables")]
    public float gsPlayerHealth;
    public Vector3 gsPlayerPosition;
    public Vector3 gsPlayerPositionOffset;

    [Header("Game Master Variables")]
    public float fadeTime;

    [Header("Booleans 1")]
    public bool isMainMenuActive = true;
    public bool isPlayerChangingScenes = false;
    public bool canPlayerControl = true;
    public bool toDestroyPlayer = false;
    public bool toDestroyNpc = false;

    [Header("Booleans 2")]
    public bool arePrefabsInstantiated = false;
    public bool isLoadingData = false;
    public bool isPlayerFound = false;

    [Header("Positions")]
    public Vector3 playerSpawnLocation;
    public Vector3 enemySpawnLocation;
    public Vector3 npcSpawnLocation;

    [Header("Scenes")]
    public Scene currentScene;

    [Header("Game Conditions")]
    public bool hasPlayerObtainedNPCSword = false;
    public bool hasKill5CubeQuestStarted = false;

    public bool npcDialogueOneEnded = false;


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

        Debug.Log(Application.persistentDataPath);

        currentScene = SceneManager.GetActiveScene();

        if(!currentPlayer)
        {
            isPlayerFound = false;
        }

        if(!currentPlayer && !isPlayerFound)
        {
            currentPlayer = GameObject.FindGameObjectWithTag("Player");

            if(currentPlayer)
            {
                isPlayerFound = true;
            }
        }

        if (!isMainMenuActive && !arePrefabsInstantiated && currentScene.name == "Game" && !isLoadingData)
        {
            //StartCoroutine(SpawnPrefabs());
            SpawnObjects();

            arePrefabsInstantiated = true;
        }

        if(!isMainMenuActive && !arePrefabsInstantiated && currentScene.name == "Game" && isLoadingData)
        {
            LoadObjects();

            arePrefabsInstantiated = true;
        }

    }

    public void SpawnObjects()
    {
        Instantiate(player, playerSpawnLocation + gsPlayerPositionOffset, Quaternion.Euler(0, 0, 0));

        Instantiate(npc, npcSpawnLocation, Quaternion.Euler(0, 0, 0));
    }

    public void LoadObjects()
    {
        Instantiate(player, gsPlayerPosition, Quaternion.Euler(0, 0, 0));
        Instantiate(npc, npcSpawnLocation, Quaternion.Euler(0, 0, 0));
    }





    //---------------------------------SAVING AND LOADING PLAYER DATA-----------------------------------

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(currentPlayer.GetComponent<MainPlayer>());
        Debug.Log("Player data has been saved.");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        gsPlayerHealth = data.health;

        Vector3 playerPosition;

        playerPosition.x = data.position[0];
        playerPosition.y = data.position[1];
        playerPosition.z = data.position[2];

        gsPlayerPosition = playerPosition;

        isLoadingData = true;

        isPlayerChangingScenes = true;
        isMainMenuActive = false;

        toDestroyPlayer = false;
        toDestroyNpc = false;

        StartCoroutine(StartingGame());
    }





    //---------------------------------SAVING AND LOADING GAME DATA-----------------------------------

    public void SaveGameData()
    {
        SaveSystem.SaveGameData(this);
        Debug.Log("Game Data has been saved.");
    }

    public void LoadGameData()
    {
        GameData data = SaveSystem.LoadGameData();

        hasPlayerObtainedNPCSword = data.hasPlayerObtainedSword;
        hasKill5CubeQuestStarted = data.hasKill5CubeQuestStarted;

        npcDialogueOneEnded = data.npcDialogueOneEnded;
    }


    IEnumerator StartingGame()
    {
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(1);
    }

}
