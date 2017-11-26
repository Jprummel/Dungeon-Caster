using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class DungeonComplete : MonoBehaviour {

    public delegate void DungeonCompleted();
    public static DungeonCompleted onDungeonCompleted;
    [SerializeField] private List<GameObject> _hearts = new List<GameObject>();
    [SerializeField] private List<GameObject> _heartFX = new List<GameObject>();
    [SerializeField] private List<Image> _stars = new List<Image>();
    private string _levelName;
    private int _starsEarned;
    private Player _player;
    private SaveLoadData _saveData;

	void Start () {
        onDungeonCompleted += DungeonFinished;
        Scene scene = SceneManager.GetActiveScene();
        _levelName = scene.name;
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Player>();
        _saveData = GameObject.FindGameObjectWithTag(Tags.SAVELOADOBJECT).GetComponent<SaveLoadData>();
	}
	
	void DungeonFinished () {
        if (!GameState.IsDungeonDone)
        {
            CheckFinishStats();
            if (TogglePanel.onPanelToggle != null)
            {
                TogglePanel.onPanelToggle(2);
            }
            GameState.IsDungeonDone = true;
            _saveData.SaveGame();
        }
	}

    void CheckFinishStats()
    {
        //If dungeon is finished check if the level already has a key with the levels name
        if (PlayerData.LevelStars.ContainsKey(_levelName))
        {
            _starsEarned = _player.CurrentHealth;
            StartCoroutine(ConvertLivesToStarsRoutine());
            if (_starsEarned > PlayerData.LevelStars[_levelName]) //If the new amount of stars is higher than the old value, change it
            {
                int starDifference = _starsEarned - PlayerData.LevelStars[_levelName]; //Calculate difference between old and new score
                PlayerData.LevelStars[_levelName] = _starsEarned;
                PlayerData.AcquiredStars += starDifference;
            }            
        }
    }

    IEnumerator ConvertLivesToStarsRoutine()
    {
        //This coroutines replaces the static heart images with the heart particles that drop down
        //After a heart has dropped down , fill up a star
        for (int i = 0; i < _starsEarned; i++)
        {
            _hearts[i].SetActive(false);
            _heartFX[i].SetActive(true);
            yield return new WaitForSeconds(1);
            _stars[i].DOFillAmount(1, 1f);
        }
        yield return null;
    }

    private void OnDisable()
    {
        onDungeonCompleted -= DungeonFinished;
        GameState.IsDungeonDone = false;
    }
}
