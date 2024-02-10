using UnityEngine;
using System.IO;
using UnityEditor;


[System.Serializable]
public static class Save_Sys
{
    public static void SavePlayer(ControlPlayer player)
    {
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");

        string jsonData = JsonUtility.ToJson(new PlayerData(player));

        File.WriteAllText(path, jsonData);

        Debug.Log("Player saved! " + path);
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);

            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);

            Debug.Log("Player loaded!");
            return data;
        }
        else
        {
            Debug.Log("Failed to load player data because of missing file!" + path);
            return null;
        }
    }
}