using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavingSystem
{
    private const string DATA_PATH = "/ropeMonster";

    public static void Save(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetDataPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static GameData Load()
    {
        //No file found

        if (!File.Exists(GetDataPath()))
        {
            GameData emptyData = null;
            Save(emptyData);
            return emptyData;
        }

        //Deserialize and return data

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetDataPath(), FileMode.Open);
        GameData gameData = formatter.Deserialize(fs) as GameData;
        fs.Close();

        return gameData;
    }

    private static string GetDataPath()
    {
        return Application.persistentDataPath + DATA_PATH;
    }
}