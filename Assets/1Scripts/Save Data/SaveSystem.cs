using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{




    public static void SavePlayer(MainPlayer player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.savdat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveGameData(GameScript masterScript)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameData.savdat";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(masterScript);

        formatter.Serialize(stream, data);
        stream.Close();
    }









    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.savdat";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data =  formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }

        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static GameData LoadGameData()
    {
        string path = Application.persistentDataPath + "/gameData.savdat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }

        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
