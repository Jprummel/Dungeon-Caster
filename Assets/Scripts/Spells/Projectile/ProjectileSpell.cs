using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell {

    [SerializeField] protected float _destroyTime;

    protected virtual void Awake()
    {
        _spellType = SpellTypes.PROJECTILE;
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == Tags.ENEMY)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(this);
            Destroy(this.gameObject, _destroyTime);
        }
    }
}
