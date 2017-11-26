using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    
    private AsyncOperation _async = null;
    private bool _isLoading;
    private string _sceneName;

    private void Awake()
    {
        ClearGameStates();
        _sceneName = SceneManager.GetActiveScene().name;
    }

    public void ChangeScene(string sceneName)
    {
        if (!_isLoading)
        {
            StartCoroutine(ChangeSceneRoutine(sceneName));
        }
    }

    public void ReloadScene()
    {
        if (!_isLoading)
        {
            StartCoroutine(ChangeSceneRoutine(_sceneName));
        }
    }

    IEnumerator ChangeSceneRoutine(string sceneName)
    {
        if (ScreenFader.onScreenFade != null)
        {
            ScreenFader.onScreenFade(1, 1.4f);
        }
        yield return new WaitForSeconds(1.5f);
        _async = SceneManager.LoadSceneAsync(sceneName);
        GameState.IsGameOver = false;
        _isLoading = true;
    }

    void ClearGameStates()
    {
        //This function resets the gamestates so there wont be any problems during the game at the start of the scene
        GameState.IsPaused = false;
        GameState.EnemiesPaused = false;
        GameState.PlayerPaused = false;
        GameState.IsGameOver = false;
        GameState.CanSwipe = true;
    }

}
