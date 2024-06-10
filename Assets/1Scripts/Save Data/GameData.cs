using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class GameData
{
    public float gsPlayerHealth;

    public bool isPlayerAlive;

    public int caveEnemyCounter;

    public bool hasPlayerObtainedSword;

    public bool hasKill5CubeQuestStarted;
    public bool hasKill5CubeQuestFinished;

    public bool npcDialogueOneEnded;
    public bool npcDialogueTwoEnded;
    public bool npcDialogueThreeEnded;

    public bool isCaveDoorOpen;

    public float[] checkpointPosition;

    public GameData(GameScript masterScript)
    {
        gsPlayerHealth = masterScript.gs_PlayerHealth;

        isPlayerAlive = masterScript.isPlayerAlive;

        caveEnemyCounter = masterScript.caveEnemyCounter;

        hasPlayerObtainedSword = masterScript.hasPlayerObtainedNPCSword;

        hasKill5CubeQuestStarted = masterScript.hasKill5CubeQuestStarted;
        hasKill5CubeQuestFinished = masterScript.hasKill5CubeQuestFinished;

        npcDialogueOneEnded = masterScript.npcDialogueOneEnded;
        npcDialogueTwoEnded = masterScript.npcDialogueTwoEnded;
        npcDialogueThreeEnded = masterScript.npcDialogueThreeEnded;

        isCaveDoorOpen = masterScript.isCaveDoorOpen;

        checkpointPosition = new float[3];
        checkpointPosition[0] = masterScript.gs_CheckpointPosition.x;
        checkpointPosition[1] = masterScript.gs_CheckpointPosition.y;
        checkpointPosition[2] = masterScript.gs_CheckpointPosition.z;
    }

}
