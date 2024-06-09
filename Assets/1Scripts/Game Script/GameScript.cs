using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public int caveEnemyCounter;

    [Header("Booleans 1")]
    public bool isMainMenuActive = true;
    public bool hasGameStarted = false;
    public bool isPlayerChangingScenes = false;
    public bool isDialogueActive = false;
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

    public bool npcDialogueOneEnded = false;
    public bool npcDialogueTwoEnded = false;
    public bool npcDialogueThreeEnded = false;

    public bool isCaveDoorOpen = false;

    [Header("Quests")]
    public bool hasKill5CubeQuestStarted = false;
    public bool hasKill5CubeQuestFinished = false;



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

        if (!isMainMenuActive && !hasGameStarted && !arePrefabsInstantiated && currentScene.name == "Game" && !isLoadingData)
        {
            StartGame();

            arePrefabsInstantiated = true;
            hasGameStarted = true;
        }

        if(!isMainMenuActive && !arePrefabsInstantiated && currentScene.name == "Game" && isLoadingData)
        {
            LoadObjects();

            arePrefabsInstantiated = true;
            isLoadingData = false;
        }


    //--------------------------------------------ALL QUESTS-------------------------------------------

        if (hasKill5CubeQuestStarted)
        {
            if(caveEnemyCounter == 0)
            {
                hasKill5CubeQuestFinished = true;
            }
        }

    }


    //----------------------------------SPAWNING + DESPAWNING OBJECTS----------------------------------

    public void StartGame()
    {
        Instantiate(player, playerSpawnLocation + gsPlayerPositionOffset, Quaternion.Euler(0, 0, 0));
        Instantiate(npc, npcSpawnLocation, Quaternion.Euler(0, 0, 0));

        caveEnemyCounter = 5;

        hasPlayerObtainedNPCSword = false;

        hasKill5CubeQuestStarted = false;
        hasKill5CubeQuestFinished = false;

        npcDialogueOneEnded = false;
        npcDialogueTwoEnded = false;
        npcDialogueThreeEnded = false;

        isCaveDoorOpen = false;

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

        caveEnemyCounter = data.caveEnemyCounter;

        hasPlayerObtainedNPCSword = data.hasPlayerObtainedSword;

        hasKill5CubeQuestStarted = data.hasKill5CubeQuestStarted;
        hasKill5CubeQuestFinished = data.hasKill5CubeQuestFinished;

        npcDialogueOneEnded = data.npcDialogueOneEnded;
        npcDialogueTwoEnded = data.npcDialogueTwoEnded;
        npcDialogueThreeEnded = data.npcDialogueThreeEnded;

        isCaveDoorOpen = data.isCaveDoorOpen;
    }


    IEnumerator StartingGame()
    {
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(1);
    }

}
