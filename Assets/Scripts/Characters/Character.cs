using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    
    [SerializeField] protected int _maxHealth;
    protected int _currentHealth;
    protected Animator _animator;

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
