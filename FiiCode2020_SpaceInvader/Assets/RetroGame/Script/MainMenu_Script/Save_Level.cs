using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class Save_Level : MonoBehaviour
{
    public int currentLevel;
    public bool[] DataLevel = new bool[10];
    public static Save_Level Instance;
    public int inputIndex;
    void Awake()
    {
        InstantiateController();
        LoadFile();
    }
    private void InstantiateController()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
            Destroy(gameObject);
    }
    public void UpdateInput(int index)
    {
        inputIndex = index;
        SaveFile();
    }
    public void SaveFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string destination = Application.persistentDataPath + "/SaveGame2.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        LevelData data = new LevelData();

        data.level_1 = DataLevel[0];
        data.level_2 = DataLevel[1];
        data.level_3 = DataLevel[2];
        data.level_4 = DataLevel[3];
        data.level_5 = DataLevel[4];
        data.level_6 = DataLevel[5];
        data.level_7 = DataLevel[6];
        data.level_8 = DataLevel[7];
        data.level_9 = DataLevel[8];
        data.level_10 = DataLevel[9];
        data.inputIndex = inputIndex;
        
        bf.Serialize(file, data);
        file.Close();
    }
    public void LoadFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string destination = Application.persistentDataPath + "/SaveGame2.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            RestFile();
            return;
        }
        LevelData data = (LevelData)bf.Deserialize(file);
        file.Close();
        DataLevel[0] = data.level_1;
        DataLevel[1] = data.level_2;
        DataLevel[2] = data.level_3;
        DataLevel[3] = data.level_4;
        DataLevel[4] = data.level_5;
        DataLevel[5] = data.level_6;
        DataLevel[6] = data.level_7;
        DataLevel[7] = data.level_8;
        DataLevel[8] = data.level_9;
        DataLevel[9] = data.level_10;
        inputIndex = data.inputIndex;
    }
    public void RestFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string destination = Application.persistentDataPath + "/SaveGame2.dat";
        FileStream file;

        if (File.Exists(destination))
            file = File.OpenWrite(destination);
        else
            file = File.Create(destination);

        LevelData data = new LevelData();

        data.level_1 = true;
        data.level_2 = false;
        data.level_3 = false;
        data.level_4 = false;
        data.level_5 = false;
        data.level_6 = false;
        data.level_7 = false;
        data.level_8 = false;
        data.level_9 = false;
        data.level_10 = false;
        data.inputIndex = 1;
        bf.Serialize(file, data);
        file.Close();

        LoadFile();
    }
    public void InitializeLevel(int lv)
    {
        currentLevel = lv;
    }
    public void IncreaseLevel()
    {
        currentLevel++;
    }
}
[Serializable]
class LevelData
{
    public int inputIndex;
    public bool level_1;
    public bool level_2;
    public bool level_3;
    public bool level_4;
    public bool level_5;
    public bool level_6;
    public bool level_7;
    public bool level_8;
    public bool level_9;
    public bool level_10;
}