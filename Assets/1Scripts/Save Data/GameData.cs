using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public bool hasPlayerObtainedSword;
    public bool hasKill5CubeQuestStarted;

    public bool npcDialogueOneEnded;

    public GameData(GameScript masterScript)
    {
        hasPlayerObtainedSword = masterScript.hasPlayerObtainedNPCSword;
        hasKill5CubeQuestStarted = masterScript.hasKill5CubeQuestStarted;

        npcDialogueOneEnded = masterScript.npcDialogueOneEnded;
    }

}
