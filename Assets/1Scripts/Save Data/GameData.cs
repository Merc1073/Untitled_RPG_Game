using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int caveEnemyCounter;

    public bool hasPlayerObtainedSword;

    public bool hasKill5CubeQuestStarted;
    public bool hasKill5CubeQuestFinished;

    public bool npcDialogueOneEnded;
    public bool npcDialogueTwoEnded;
    public bool npcDialogueThreeEnded;

    public bool isCaveDoorOpen;

    public GameData(GameScript masterScript)
    {
        caveEnemyCounter = masterScript.caveEnemyCounter;

        hasPlayerObtainedSword = masterScript.hasPlayerObtainedNPCSword;

        hasKill5CubeQuestStarted = masterScript.hasKill5CubeQuestStarted;
        hasKill5CubeQuestFinished = masterScript.hasKill5CubeQuestFinished;

        npcDialogueOneEnded = masterScript.npcDialogueOneEnded;
        npcDialogueTwoEnded = masterScript.npcDialogueTwoEnded;
        npcDialogueThreeEnded = masterScript.npcDialogueThreeEnded;

        isCaveDoorOpen = masterScript.isCaveDoorOpen;
    }

}
