using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowLevelRanking : MonoBehaviour {

    [SerializeField] private string _dungeonName;
    [SerializeField] private List<Image> _starImages = new List<Image>();
    private int _stars;
    private bool _showingStars;
    
	void Start () {
        _stars = PlayerData.LevelStars[_dungeonName]; // Gets the amount of stars for the level this object is on
        ShowStars();
	}

    void ShowStars()
    {
        StartCoroutine(ShowStarRoutine());
    }

    IEnumerator ShowStarRoutine()
    {
        if (!_showingStars)
        {
            _showingStars = true;
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < _stars; i++)
            {
                _starImages[i].DOFillAmount(1, 2); // Small animation to fill up the stars
            }
        }
    }
}
