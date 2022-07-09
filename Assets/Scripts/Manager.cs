using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public string InputName;
    public string BestName;
    public string BestScore;


    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Reset();
        LoadBest();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestName;
        public string BestScore;
    }

    public void SaveBest()
    {
        SaveData data = new SaveData();
        data.BestName = BestName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestName = data.BestName;
            BestScore = data.BestScore;
        }
    }

    private void Reset()
    {
        SaveData data = new SaveData();
        data.BestName = " ";
        data.BestScore = "0";

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


}
