using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public delegate void GameOverEvent();
    public static GameOverEvent onGameOver;
    
    private bool _isGameOver;

	void Start () {
        onGameOver += CheckForGameOver;
	}

    void CheckForGameOver()
    {
        if (!GameState.IsGameOver)
        {
            TogglePanel.onPanelToggle(3);
            GameState.IsGameOver = true;
        }
    }

    private void OnDisable()
    {
        onGameOver -= CheckForGameOver;
    }
}
