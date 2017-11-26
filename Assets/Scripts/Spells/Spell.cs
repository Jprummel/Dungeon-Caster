using UnityEngine;

public class Spell : MonoBehaviour {

    //Spell identifiers
    [SerializeField]protected DamageTypes _spellDamageType;
    protected string _spellType;
    protected string _soundEffectTag;

    //Checks if one enemy is already hit to prevent double hits
    protected bool _enemyHit;

    [SerializeField] protected int _spellDamage;

    public string SpellType
    {
        get { return _spellType; }
        set { _spellType = value; }
    }

    public DamageTypes SpellDamageType
    {
        get { return _spellDamageType; }
        set { _spellDamageType = value; }
    }

    public string SoundEffectTag
    {
        get { return _soundEffectTag; }
        set { _soundEffectTag = value; }
    }

    public int SpellDamage
    {
        get { return _spellDamage; }
        set { _spellDamage = value; }
    }

    public bool EnemyHit
    {
        get { return _enemyHit; }
        set { _enemyHit = value; }
    }
}
