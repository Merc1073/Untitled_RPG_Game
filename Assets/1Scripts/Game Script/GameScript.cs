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
    public GameObject enemy;
    public GameObject npc;

    [Header("GS Variables")]
    public float gs_Timer;
    public float gs_OriginalTimer;
    public bool gs_IsTimerActive = false;

    [Header("Player Variables")]
    public GameObject gs_CurrentPlayer;
    public float gs_PlayerHealth;
    public float gs_PlayerRespawnTime;
    public Vector3 gs_PlayerPosition;
    public Vector3 gs_PlayerPositionOffset;
    public Vector3 gs_PlayerCameraOffset;
    public bool gs_hasCameraActivated;

    [Header("Player Booleans")]
    public bool isPlayerChangingScenes = false;
    public bool canPlayerControl = true;
    public bool isPlayerFound = false;
    public bool isPlayerAlive = true;

    [Header("Game Master Variables")]
    public float fadeTime;
    public float fadeCooldown;
    public int caveEnemyCounter;
    public bool gs_useNormalFadeAnim = false;
    public bool gs_useFadeOutOnly = false;

    [Header("Booleans 1")]
    public bool isMainMenuActive = true;
    public bool hasGameStarted = false;
    public bool isDialogueActive = false;
    public bool toDestroyPlayer = false;
    public bool toDestroyNpc = false;

    [Header("Booleans 2")]
    public bool arePrefabsInstantiated = false;
    public bool isLoadingData = false;

    [Header("Current Checkpoint")]
    public GameObject gs_Checkpoint;
    public Vector3 gs_CheckpointPosition;
    public Vector3 gs_CheckpointOffset;
    //public bool gs_hasPlayerRespawned = false;

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

        currentScene = SceneManager.GetActiveScene();

        if(gs_hasCameraActivated && gs_CurrentPlayer)
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gs_CurrentPlayer.gameObject.transform.position + gs_PlayerCameraOffset;
            canPlayerControl = true;
            gs_hasCameraActivated = false;
        }

        if (!gs_CurrentPlayer)
        {
            isPlayerFound = false;
        }

        else
        {
            isPlayerFound = true;
        }
        

        if (!isMainMenuActive && !hasGameStarted && !arePrefabsInstantiated && currentScene.name == "Game" && !isLoadingData)
        {
            StartNewGame();

            arePrefabsInstantiated = true;
            hasGameStarted = true;
        }

        if(!isMainMenuActive && !arePrefabsInstantiated && currentScene.name == "Game" && isLoadingData)
        {
            LoadGame();
 
            arePrefabsInstantiated = true;
            isLoadingData = false;

            gs_hasCameraActivated = true;
        }

        if(gs_Checkpoint)
        {
            gs_CheckpointPosition = gs_Checkpoint.transform.position;
            Debug.Log("Current checkpoint position is: " + gs_CheckpointPosition);
        }

        if(!gs_IsTimerActive)
        {
            gs_Timer = gs_OriginalTimer;
        }

        if(gs_IsTimerActive)
        {
            gs_Timer -= Time.deltaTime;
        }

        if (!isPlayerAlive && gs_CurrentPlayer)
        {
            gs_CurrentPlayer.transform.parent.gameObject.SetActive(false);

            gs_IsTimerActive = true;

            if(gs_Timer <= 0f)
            {
                isPlayerChangingScenes = true;
                //gs_useFadeOutOnly = true;

                fadeCooldown -= Time.deltaTime;
                gs_useNormalFadeAnim = true;

                if (fadeCooldown <= 0f)
                {
                    LoadGameData();
                }
            }
        }

        if (isPlayerAlive && gs_CurrentPlayer)
        {
            gs_CurrentPlayer.gameObject.SetActive(true);
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

    public void StartNewGame()
    {
        Instantiate(player, playerSpawnLocation + gs_PlayerPositionOffset, Quaternion.Euler(0, 0, 0));
        Instantiate(npc, npcSpawnLocation, Quaternion.Euler(0, 0, 0));

        isPlayerAlive = true;

        caveEnemyCounter = 5;

        hasPlayerObtainedNPCSword = false;

        hasKill5CubeQuestStarted = false;
        hasKill5CubeQuestFinished = false;

        npcDialogueOneEnded = false;
        npcDialogueTwoEnded = false;
        npcDialogueThreeEnded = false;

        isCaveDoorOpen = false;

    }

    public void LoadGame()
    {
        Instantiate(player, gs_PlayerPosition, Quaternion.Euler(0, 0, 0));
        Instantiate(npc, npcSpawnLocation, Quaternion.Euler(0, 0, 0));
        Debug.Log("Objects loaded.");
    }





    //---------------------------------SAVING AND LOADING PLAYER DATA-----------------------------------

    //public void SavePlayer()
    //{
    //    SaveSystem.SavePlayer(gs_CurrentPlayer.GetComponent<MainPlayer>());
    //    Debug.Log("Player data has been saved.");
    //}

    public void LoadPlayer()
    {
        //PlayerData data = SaveSystem.LoadPlayer();

        //gsPlayerHealth = data.health;

        //Vector3 playerPosition;

        //playerPosition.x = data.position[0];
        //playerPosition.y = data.position[1];
        //playerPosition.z = data.position[2];

        //gs_PlayerPosition = playerPosition;

        
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

        gs_CheckpointPosition.x = data.checkpointPosition[0];
        gs_CheckpointPosition.y = data.checkpointPosition[1];
        gs_CheckpointPosition.z = data.checkpointPosition[2];

        Debug.Log(gs_CheckpointPosition);

        gs_PlayerPosition = gs_CheckpointPosition + gs_CheckpointOffset;

        isPlayerAlive = data.isPlayerAlive;

        caveEnemyCounter = data.caveEnemyCounter;

        hasPlayerObtainedNPCSword = data.hasPlayerObtainedSword;

        hasKill5CubeQuestStarted = data.hasKill5CubeQuestStarted;
        hasKill5CubeQuestFinished = data.hasKill5CubeQuestFinished;

        npcDialogueOneEnded = data.npcDialogueOneEnded;
        npcDialogueTwoEnded = data.npcDialogueTwoEnded;
        npcDialogueThreeEnded = data.npcDialogueThreeEnded;

        if(gs_useFadeOutOnly)
        {
            gs_useNormalFadeAnim = false;
        }

        else
        {
            gs_useNormalFadeAnim = true;
        }

        isCaveDoorOpen = data.isCaveDoorOpen;

        //isPlayerChangingScenes = true;

        arePrefabsInstantiated = false;

        isLoadingData = true;

        isMainMenuActive = false;

        toDestroyPlayer = false;
        toDestroyNpc = false;

        isPlayerAlive = true;

        fadeCooldown = fadeTime;

        StartingGame();

    }

    public void StartingGame()
    {

        SceneManager.LoadScene(1);
        gs_useFadeOutOnly = false;
        gs_useNormalFadeAnim = false;
        gs_IsTimerActive = false;
        Debug.Log("Scene changed.");

    }

    public void LoadGameFade()
    {
        gs_useNormalFadeAnim = true;

        StartCoroutine(StartingLoad());
    }

    IEnumerator StartingLoad()
    {
        yield return new WaitForSeconds(fadeTime);

        LoadGameData();
    }

    //public void GSTimerSetter(float time)
    //{
    //    gs_Timer = time;

    //    GSTimer();
    //}

    //public void GSTimer()
    //{
    //    gs_Timer -= Time.deltaTime;

    //    if(gs_Timer <= 0f)
    //    {
    //        LoadGameData();
    //    }
    //}

    //public void PlayerRespawning()
    //{
    //    LoadGameData();
    //}

    //IEnumerator StartingGame()
    //{
    //    yield return new WaitForSeconds(fadeTime);

    //    SceneManager.LoadScene(1);
    //    //LoadObjects();
    //}

    //IEnumerator PlayerRespawning()
    //{

    //    gs_CurrentPlayer.transform.parent.gameObject.SetActive(false);

    //    yield return new WaitForSeconds(gs_PlayerRespawnTime);

    //    LoadGameData();

    //}

}
