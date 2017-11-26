using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePause : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        GameState.IsPaused = false; // At the start of a scene set the gamestate to not paused so enemies can move
    }

    public void PauseToggle()
    {
        if (GameState.IsPaused)
        {
            GameState.IsPaused = false;
        }else if (!GameState.IsPaused)
        {
            GameState.IsPaused = true;
        }
    }
}
