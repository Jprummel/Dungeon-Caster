using System.Collections;
using UnityEngine;

public class Player : Character {
    
    [SerializeField] private GameObject _protectionParticle;
    private PlayerAnimations _playerAnims;

    protected override void Awake()
    {
        base.Awake();
        _playerAnims = GetComponent<PlayerAnimations>();
    }

    void Start () {
        _currentHealth = _maxHealth;
	}
	
    public void TakeDamage()
    {
        _currentHealth--;
        if(_currentHealth >= 1)
        {
            //If health is above 1 or above after being hit, spawn the protection particle
            GameObject protectParticle = Instantiate(_protectionParticle);
            protectParticle.transform.position = this.transform.position;
        }
        PlayerHealth.onChangeHealth(_currentHealth);
        StartCoroutine(TakeDamageRoutine());
    }

    IEnumerator TakeDamageRoutine()
    {
        if (_currentHealth <= 0)
        {
            _playerAnims.DeathAnimation();
            yield return new WaitForSeconds(2);
            GameOver.onGameOver();
        }
        _playerAnims.HitAnimation();
    }

}
