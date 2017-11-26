using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowCurrentStars : MonoBehaviour {

    [SerializeField] private Transform _starBorder;
    [SerializeField] private Transform _starFill;
    private bool _isScaling;
    [SerializeField] private Text _currentStarsText;

	void Awake () {
        _currentStarsText.text = PlayerData.AcquiredStars.ToString();
	}

    void Update()
    {
        if (!_isScaling)
        {
            StartCoroutine(BounceAnimation());
        }
    }

    IEnumerator BounceAnimation()
    {
        _isScaling = true;
        _starBorder.DOScale(0.8f, 1);
        _starFill.DOScale(0.8f, 1);
        yield return new WaitForSeconds(1);
        _starBorder.DOScale(1, 1);
        _starFill.DOScale(1, 1);
        yield return new WaitForSeconds(2.5f);
        _isScaling = false;
    }
}
