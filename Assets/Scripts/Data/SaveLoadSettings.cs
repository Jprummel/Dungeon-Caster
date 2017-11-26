using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSettings : MonoBehaviour {
    
	void Awake () {
        LoadSettings();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveSettings()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gewoonboefsettings.man");

        SettingsData settingsData = new SettingsData();
        //Put all saveable data here,saveData.value = someScript.value
        settingsData.MasterVolume = GameSettingsData.MasterVolume;
        settingsData.MusicVolume = GameSettingsData.MusicVolume;
        settingsData.SFXVolume = GameSettingsData.SFXVolume;
        bf.Serialize(file, settingsData);
        file.Close();
    }

    public void LoadSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/gewoonboefsettings.man"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gewoonboefsettings.man", FileMode.Open);

            SettingsData settingsData = (SettingsData)bf.Deserialize(file);
            //Load all the data here, someScript.value = saveData.value
            GameSettingsData.MasterVolume = settingsData.MasterVolume;
            GameSettingsData.MusicVolume = settingsData.MusicVolume;
            GameSettingsData.SFXVolume = settingsData.SFXVolume;
            file.Close();
        }
        else { 
            GameSettingsData.MasterVolume = -40;
            GameSettingsData.MusicVolume = 0;
            GameSettingsData.SFXVolume = 0;            
        }
    }
}

[System.Serializable]
public class SettingsData
{
    public float MasterVolume;
    public float MusicVolume;
    public float SFXVolume;
}
