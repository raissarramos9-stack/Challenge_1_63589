using System.IO;
using UnityEngine;

public class DataManager100 : MonoBehaviour
{
    public static DataManager100 Instance;

    public string PlayerName;

    public string BestPlayerName;
    public int BestScore;

    [System.Serializable]
    private class SaveDataClass
    {
        public string playerName;
        public int bestScore;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    public void SaveData()
    {
        SaveDataClass data = new SaveDataClass();

        data.playerName = BestPlayerName;
        data.bestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(
            Application.persistentDataPath + "/savefile.json",
            json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveDataClass data =
                JsonUtility.FromJson<SaveDataClass>(json);

            BestPlayerName = data.playerName;
            BestScore = data.bestScore;
        }
    }
}