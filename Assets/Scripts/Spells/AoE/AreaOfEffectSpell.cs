using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectSpell : Spell {

    protected virtual void Awake()
    {
        _spellType = SpellTypes.AREA_OF_EFFECT;
    }
}
