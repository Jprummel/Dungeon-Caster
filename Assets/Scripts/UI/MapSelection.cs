using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour {

    [SerializeField] private List<GameObject> _mapSelectPages = new List<GameObject>();
    [SerializeField] private GameObject _previousButton;
    [SerializeField] private GameObject _nextButton;

    private int _currentPage = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PreviousPage()
    {
        if(_currentPage > 0)
        {
            _currentPage--;
            for (int i = 0; i < _mapSelectPages.Count; i++)
            {
                _mapSelectPages[i].SetActive(false);
                if(i == _currentPage)
                {
                    _mapSelectPages[i].SetActive(true);
                }
            }
            if (_currentPage <= 0)
            {
                _previousButton.SetActive(false);
            }
            if(_currentPage < _mapSelectPages.Count-1)
            {
                _nextButton.SetActive(true);
            }
        }
    }

    public void NextPage()
    {
        if (_currentPage < _mapSelectPages.Count)
        {
            _currentPage++;
            for (int i = 0; i < _mapSelectPages.Count; i++)
            {
                _mapSelectPages[i].SetActive(false);
                if (i == _currentPage)
                {
                    _mapSelectPages[i].SetActive(true);
                }
            }
            if (_currentPage >= _mapSelectPages.Count-1)
            {
                _nextButton.SetActive(false);
            }
            if(_currentPage > 0)
            {
                _previousButton.SetActive(true);
            }
        }
    }
}
