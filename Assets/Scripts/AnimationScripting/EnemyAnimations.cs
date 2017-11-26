using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {

    private Animator _anim;

	void Awake () {
        _anim = GetComponent<Animator>();
	}
	
	void Update () {
		if(GameState.IsPaused || GameState.EnemiesPaused)
        {
            _anim.speed = 0;
        }
        else
        {
            _anim.speed = 1;
        }
	}

    public void AttackAnimation()
    {
        _anim.SetTrigger("IsAttacking");
    }

    public void HitAnimation()
    {
        _anim.SetTrigger("GotHit");
    }

    public void DeathAnimation()
    {
        _anim.SetBool("IsDead", true);
    }
}
