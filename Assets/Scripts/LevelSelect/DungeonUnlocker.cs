using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUnlocker : MonoBehaviour {

    [SerializeField] private int _starsNeededForUnlock;
    [SerializeField] private string _LevelName;
    [SerializeField] private Button _levelButton;

    private bool _isUnlocked;


	void Start () {
        CheckForUnlock();
        UnlockDungeon();
	}

	void Update () {
		
	}

    void CheckForUnlock()
    {
        if(PlayerData.AcquiredStars >= _starsNeededForUnlock)
        {
            _isUnlocked = true;
        }
        else
        {
            _isUnlocked = false;
        }
    }

    void UnlockDungeon()
    {
        if (_isUnlocked)
        {
            _levelButton.interactable = true;
        }
        else
        {
            _levelButton.interactable = false;
        }
    }
}
