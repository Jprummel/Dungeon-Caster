using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadData : MonoBehaviour {

    public delegate void SaveEvent();
    public static SaveEvent onSave;
    
	void Awake () {
        DontDestroyOnLoad(this.gameObject);
        onSave += SaveGame;
        LoadGame();
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }


    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gewoonboef.man");
        
        SaveData saveData = new SaveData();
        //Put all saveable data here,saveData.value = someScript.value
        saveData.AcquiredStars = PlayerData.AcquiredStars;
        saveData.CompletedTutorial = PlayerData.CompletedTutorial;
        saveData.LevelStars = PlayerData.LevelStars;
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gewoonboef.man"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gewoonboef.man", FileMode.Open);

            SaveData saveData = (SaveData)bf.Deserialize(file);
            //Load all the data here, someScript.value = saveData.value
            PlayerData.AcquiredStars = saveData.AcquiredStars;
            PlayerData.CompletedTutorial = saveData.CompletedTutorial;
            PlayerData.LevelStars = saveData.LevelStars;
            file.Close();
        }
    }

    public void ClearSave()
    {
        if(File.Exists(Application.persistentDataPath + "/gewoonboef.man"))
        {
            File.Delete(Application.persistentDataPath + "/gewoonboef.man");
        }
        //Resets all values
        PlayerData.AcquiredStars = 0;
        PlayerData.CompletedTutorial = false;
        foreach (var key in PlayerData.LevelStars.Keys.ToList())
        {
            PlayerData.LevelStars[key] = 0;
        }
    }

    private void OnDisable()
    {
        onSave -= SaveGame;
    }
}

[System.Serializable]
public class SaveData
{
    public int AcquiredStars;
    public bool CompletedTutorial;
    public Dictionary<string, int> LevelStars;
}
