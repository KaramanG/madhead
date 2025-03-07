using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class saveSystem
{
    public static void savePlayer(playerData data, int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player" + saveNumber + ".dat";

        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            killPointCounter dataCounter = new killPointCounter(data);
            formatter.Serialize(fileStream, dataCounter);
        }

        
    }

    public static killPointCounter loadPlayer(int saveNumber)
    {
        string path = Application.persistentDataPath + "/player" + saveNumber + ".dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                killPointCounter dataCounter = formatter.Deserialize(fileStream) as killPointCounter;
                return dataCounter;
            } 
        }
        else
        {
            Debug.Log("Сохраниение не нашлось в " + path);
            return null;
        }    
    }

    public static bool exists(int saveNumber)
    {
        string path = Application.persistentDataPath + "/player" + saveNumber + ".dat";
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
