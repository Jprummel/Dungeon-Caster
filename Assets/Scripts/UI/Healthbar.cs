using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Healthbar : MonoBehaviour {

    [SerializeField] private Image _healthBar;

    public void ChangeHealth(float currentHealth, float maxHealth)
    {
        _healthBar.DOFillAmount(currentHealth / maxHealth,0.5f);
    }
}
