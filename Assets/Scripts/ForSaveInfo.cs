using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ForSaveInfo : MonoBehaviour
{
    public static ForSaveInfo instance { get; private set; }

    public string namePlayer;
    public int ScoreToSave;
    public int coins;

    public string bestPlayer { get; private set; }
    public int bestScore { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        bestPlayer = namePlayer;
        bestScore = ScoreToSave;
    }


    public void SaveGame()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        SaveData data = new SaveData();
        if (bestScore < ScoreToSave)
        {
            bestScore = ScoreToSave;
            bestPlayer = namePlayer;
        }
            data.score = bestScore;
            data.name = bestPlayer;
        
        data.coins = coins;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("I save");
        Debug.Log($"{ScoreToSave}");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            bestPlayer = data.name;
            bestScore = data.score;
            coins = data.coins;
            Debug.Log("I load");
        }
        else
            Debug.Log("No Save Data");

    }


    [System.Serializable]
    class SaveData
    {
        public  int score;
        public string name;
        public int coins;
    }
}
