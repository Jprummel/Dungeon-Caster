using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialProgress : MonoBehaviour {

    public delegate void TutorialProgressEvent(int tutorialProgress);
    public static TutorialProgressEvent onTutorialProgress;
    
    [SerializeField] private bool _isTutorial = false;

    [SerializeField] private List<GameObject> _tutorialPanels = new List<GameObject>();

    private EnemySpawner _enemySpawner;

    private int _orderInLayer;

    private Canvas _canvas;

    private int _tutorialCount = 10;

    private bool _couldSkip;

    public bool IsTutorial
    {
        get { return _isTutorial; }
        set { _isTutorial = value; }
    }

    public int TutorialCounter
    {
        get { return _tutorialCount; }
        set { _tutorialCount = value; }
    }
	// Use this for initialization
	void Start () {
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        _couldSkip = false;
        _tutorialCount = 0;
        if (_isTutorial)
        {
            GameState.CanSwipe = false;
            StartCoroutine(ProgressionCheck1());
        }
        else {
            GameState.CanSwipe = true;
        }
	}

    void Update()
    {
        if (Input.GetMouseButton(0) && _couldSkip && _isTutorial)
        {
            StartCoroutine(ProgressionCheck2());
            StartCoroutine(Progressioncheck4());
        }

        if (_tutorialCount == 4)
        {
            TogglePauseCharacters(true);
        }

        if(_tutorialCount == 5 && _enemySpawner.Enemies.Count == 0 && _isTutorial)
        {
            //Checks if the last enemy is dead before showing the dungeonfinished screen
            StartCoroutine(FinishedTutorial());
        }
    }

    IEnumerator ProgressionCheck1()
    {
        //start of the first tutorial
        TutorialSpawning.onSpawnGecko();
        yield return new WaitForSeconds(2.5f);
        TogglePauseCharacters(true);
        _tutorialPanels[0].gameObject.SetActive(true);
        _tutorialCount = 0;
        _couldSkip = true;
    }

    IEnumerator ProgressionCheck2() {
        if (_tutorialCount == 0)
        {
            _couldSkip = false;
            TogglePauseCharacters(false);
            _tutorialPanels[0].gameObject.SetActive(false);

            //end of the first tutorial

            yield return new WaitForSeconds(1f);
            _tutorialCount = 1;
            NextTutorial();
        }
    }

    IEnumerator ProgressionCheck3()
    {
        //start of the 3e tutorial
        yield return new WaitForSeconds(4f);
        TutorialSpawning.onSpawnComododragon();
        yield return new WaitForSeconds(1.5f);
        TogglePauseCharacters(true);
        _tutorialPanels[2].gameObject.SetActive(true);
        _tutorialCount = 3;
        _couldSkip = true;
    }

    IEnumerator Progressioncheck4()
    {
        if (_tutorialCount == 3)
        {
            _couldSkip = false;
            TogglePauseCharacters(false);
            _tutorialPanels[2].gameObject.SetActive(false);

            //end of the 3e tutorial

            yield return new WaitForSeconds(1.5f);
            _tutorialCount = 4;
            NextTutorial();
        }
    }

    private void NextTutorial()
    {
        //_tutorialCount = +1;

        if (_tutorialCount == 1)
        {
            //start of the 2th tutorial

            TogglePauseCharacters(true);
            _tutorialPanels[1].gameObject.SetActive(true);
            GameState.CanSwipe = true;
        }
        if (_tutorialCount == 2)
        {
            TogglePauseCharacters(false);
            _tutorialPanels[1].gameObject.SetActive(false);
            GameState.CanSwipe = false;
            //end of the 2th tutorial

            StartCoroutine(ProgressionCheck3());
        }
        if (_tutorialCount == 4)
        {
            //start of the 4th tutorial

            TogglePauseCharacters(true);
            _tutorialPanels[3].gameObject.SetActive(true);
            GameState.CanSwipe = true;
        }
        if (_tutorialCount == 5)
        {
            TogglePauseCharacters(false);
            _tutorialPanels[3].gameObject.SetActive(false);

            //end of the 4th tutorial
        }
    }

    IEnumerator FinishedTutorial()
    {
        PlayerData.CompletedTutorial = true;
        yield return new WaitForSeconds(2);
        DungeonComplete.onDungeonCompleted();        
    }

    public void TutorialCount(int Tutorial) {
        if (Tutorial > _tutorialCount)
        {
            _tutorialCount = Tutorial;
            if (_isTutorial)
            {
                NextTutorial();
            }
        }
    }

    void TogglePauseCharacters(bool isPaused)
    {
        GameState.EnemiesPaused = isPaused;
        GameState.PlayerPaused = isPaused;
    }
}
