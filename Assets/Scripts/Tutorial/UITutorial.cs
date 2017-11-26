using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UITutorial : MonoBehaviour {
    [SerializeField]private List<GameObject> _tutorialPanels = new List<GameObject>();
    private List<Image> _tutorialPanelImages = new List<Image>();
    private List<Text> _tutorialTexts = new List<Text>();
    [SerializeField]private GameObject _healthUI;
    [SerializeField]private GameObject _waveUI;
    [SerializeField]private GameObject _runeCircleUI;
    [SerializeField]private GameObject _settingsButton;
    [SerializeField]private Image _arrowImage;
    private int _currentTutorial;
    private bool _canSkip;

    void Start () {
        for (int i = 0; i < _tutorialPanels.Count; i++)
        {
            _tutorialPanelImages.Add(_tutorialPanels[i].GetComponent<Image>());
            _tutorialTexts.Add(_tutorialPanels[i].GetComponentInChildren<Text>());
        }
        StartCoroutine(TutorialStart());
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0) && _canSkip)
        {
            _currentTutorial++;
            if(_currentTutorial < _tutorialPanels.Count)
            {
                StartCoroutine(SwitchTutorialPanels(_currentTutorial));
            }
            switch (_currentTutorial)
            {
                case 1:
                    StartCoroutine(HealthTutorial());
                    break;
                case 2:
                    StartCoroutine(WaveTutorial());
                    break;
                case 3:
                    RuneCircleTutorial();
                    break;
                case 4:
                    SettingsTutorial();
                    break;
            }
            if(_currentTutorial > _tutorialPanels.Count)
            {
                StartCoroutine(FinishUITutorial());
            }
        }
	}

    IEnumerator HealthTutorial()
    {
        yield return new WaitForSeconds(1.5f);
        _healthUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _healthUI.transform.DOLocalMove(new Vector3(-270, 850, 0), 2f);
    }

    IEnumerator WaveTutorial()
    {
        yield return new WaitForSeconds(1.5f);
        _waveUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _waveUI.transform.DOLocalMove(new Vector3(310, 850, 0), 2f);
    }

    void RuneCircleTutorial()
    {
        _runeCircleUI.SetActive(true);
    }

    void SettingsTutorial()
    {
        _settingsButton.SetActive(true);
        _arrowImage.DOFade(1, 1.5f);
    }

    IEnumerator TutorialStart()
    {
        yield return new WaitForSeconds(1.5f);
        _tutorialPanelImages[0].DOFade(1, 1.5f);
        _tutorialTexts[0].DOFade(1, 1.5f);
        yield return new WaitForSeconds(1.6f);
        _canSkip = true;
    }

    IEnumerator FinishUITutorial()
    {
        ScreenFader.onScreenFade(1, 1.5f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(LevelNames.TUTORIAL);
    }

    IEnumerator SwitchTutorialPanels(int panelIndex)
    {
        _canSkip = false;
        _tutorialPanelImages[panelIndex - 1].DOFade(0, 1.5f);
        _tutorialTexts[panelIndex - 1].DOFade(0, 1.5f);
        yield return new WaitForSeconds(1.6f);
        _tutorialPanels[panelIndex - 1].SetActive(false);
        _tutorialPanels[panelIndex].SetActive(true);
        _tutorialPanelImages[panelIndex].DOFade(1, 1.5f);
        _tutorialTexts[panelIndex].DOFade(1, 1.5f);
        yield return new WaitForSeconds(1.6f);
        _canSkip = true;
    }
}
