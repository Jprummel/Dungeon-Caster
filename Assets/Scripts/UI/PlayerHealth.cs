using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour {

    public delegate void ChangeHealthEvent(int lives);
    public static ChangeHealthEvent onChangeHealth;

    [SerializeField] private List<Image> _hearts = new List<Image>();
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

	void Start () {
        onChangeHealth += ChangeHealthUI;
	}

    void ChangeHealthUI(int lives)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            if(i >= lives)
            {
                _hearts[i].DOColor(_inactiveColor, 2);
            }
        }
    }

    private void OnDisable()
    {
        onChangeHealth -= ChangeHealthUI;
    }
}
