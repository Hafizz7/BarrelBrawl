using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

public class SaveGame : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "savegame.json");
    }

    public void SaveScore(int arenaIndex, int score)
    {
        SaveData data = LoadData();
        data.scores[arenaIndex] = score;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        UnityEngine.Debug.Log("Score saved for Arena " + arenaIndex + ": " + score);
    }

    public int LoadScore(int arenaIndex)
    {
        SaveData data = LoadData();
        if (data.scores.ContainsKey(arenaIndex))
        {
            return data.scores[arenaIndex];
        }
        return 0;
    }

    private SaveData LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        return new SaveData();
    }

    [System.Serializable]
    public class SaveData
    {
        public Dictionary<int, int> scores = new Dictionary<int, int>();
    }
}
