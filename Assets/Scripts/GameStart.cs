using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    public void SceneChange()
    {
        if (PlayerData.CompletedTutorial)
        {
            SceneManager.LoadScene(LevelNames.DUNGEON_SELECT);
        }
        else
        {
            SceneManager.LoadScene(LevelNames.UI_TUTORIAL);
        }
    }
}
