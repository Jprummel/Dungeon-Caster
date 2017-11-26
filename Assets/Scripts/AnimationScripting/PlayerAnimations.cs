using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        SpellCombos.onCastSpell += CastAnimation;
        MapProgression.onMapProgression += MoveAnimation;
        MapProgression.onStopMapProgression += StopMoveAnimation;
    }

    private void Update()
    {
        if (GameState.IsPaused || GameState.PlayerPaused)
        {
            _anim.speed = 0;
        }
        else
        {
            _anim.speed = 1;
        }
    }

    public void CastAnimation()
    {
        _anim.SetTrigger("IsCasting");
    }

    public void MoveAnimation()
    {
        _anim.SetBool("IsWalking", true);
    }

    public void StopMoveAnimation()
    {
        _anim.SetBool("IsWalking", false);
    }

    public void HitAnimation()
    {
        _anim.SetTrigger("GotHit");
    }

    public void DeathAnimation()
    {
        _anim.SetBool("IsDead", true);
    }

    private void OnDisable()
    {
        SpellCombos.onCastSpell -= CastAnimation;
        MapProgression.onMapProgression -= MoveAnimation;
        MapProgression.onStopMapProgression -= StopMoveAnimation;
    }
}
