using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCombos : MonoBehaviour {

    public delegate void SpawnSpellEvent(string combo);
    public static SpawnSpellEvent onSpawnSpell;
    public delegate void CastSpellEvent();
    public static CastSpellEvent onCastSpell;

    [SerializeField]private TutorialProgress _TutorialProgress;
    [SerializeField] private List<GameObject> _spells = new List<GameObject>();
    [SerializeField] private List<GameObject> _spellCompletedParticles = new List<GameObject>();

    //Spell spawn points
    private Transform _projectileSpawnPoint;
    private Transform _aoeSpawnPoint;
    private Transform _completedSpellParticleSpawner;
    int _spellToSpawnID;


    private EnemySpawner _enemySpawner;

    void Start () {
        onSpawnSpell += CheckSpellCombo;
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        _projectileSpawnPoint = GameObject.FindGameObjectWithTag(Tags.SPELLSPAWNPOINT).GetComponent<Transform>();
        _aoeSpawnPoint = GameObject.FindGameObjectWithTag(Tags.AOESPAWNPOINT).GetComponent<Transform>();
        _completedSpellParticleSpawner = GameObject.FindGameObjectWithTag(Tags.COMPLETEDSPELLPARTICLESPAWNER).GetComponent<Transform>();
    }

    public int SpellToSpawn(int spellToSpawn)
    {
        _spellToSpawnID = spellToSpawn;
        return _spellToSpawnID;
    }
	
    public void CheckSpellCombo(string combo)
    {
        //This function checks if the combo parameter given is the same as one of the combos in the combo class
        //If so, set the spellID to the index of that spell in the list
        if (!_TutorialProgress.IsTutorial)
        {
            //Regular list of spells when the level isnt the tutorial
            if(SpellDictionaries.FirenadoDictionary.ContainsValue(combo))
            {
                _spellToSpawnID = 0;
                SpawnSpell();
            }
            if(SpellDictionaries.WaterOrbDictionary.ContainsValue(combo))
            {
                if (PlayerData.AcquiredStars >= 3)
                {
                    _spellToSpawnID = 1;
                    SpawnSpell();
                }
            }
            if(SpellDictionaries.EarthDictionary.ContainsValue(combo))
            {
                if (PlayerData.AcquiredStars >= 5)
                {
                    _spellToSpawnID = 2;
                    SpawnSpell();
                }
            }
            if(SpellDictionaries.LightningDictionary.ContainsValue(combo))
            {
                if (PlayerData.AcquiredStars >= 8)
                {
                    _spellToSpawnID = 3;
                    SpawnSpell();
                }
            }
            if(SpellDictionaries.LightBeamDictionary.ContainsValue(combo))
            {
                _spellToSpawnID = 4;
                SpawnSpell();
            }
            if(SpellDictionaries.DarknessDictionary.ContainsValue(combo))
            {
                if (PlayerData.AcquiredStars >= 12)
                {
                    _spellToSpawnID = 5;
                    SpawnSpell();
                }
            }
        }
        else if (_TutorialProgress.IsTutorial)
        {
            if (_TutorialProgress.TutorialCounter == 1 || _TutorialProgress.TutorialCounter == 5)
            {
                if (SpellDictionaries.FirenadoDictionary.ContainsValue(combo))
                {
                    _spellToSpawnID = 0;
                    _TutorialProgress.TutorialCount(2);
                    SpawnSpell();
                }
            }
            if (_TutorialProgress.TutorialCounter == 4 || _TutorialProgress.TutorialCounter == 5)
            {
                if (SpellDictionaries.LightBeamDictionary.ContainsValue(combo))
                {
                    _spellToSpawnID = 4;
                    _TutorialProgress.TutorialCount(5);
                    SpawnSpell();
                }
            }
        }
    }

    void SpawnSpell()
    {
        //Code to instantiate the spell
        if (onCastSpell != null)
        {
            onCastSpell();
        }
        GameObject spellObject = Instantiate(_spells[_spellToSpawnID]);
        GameObject completedSpellParticle = Instantiate(_spellCompletedParticles[_spellToSpawnID]);
        
        completedSpellParticle.transform.SetParent(_completedSpellParticleSpawner);
        completedSpellParticle.transform.position = _completedSpellParticleSpawner.position;
        Spell spell = spellObject.GetComponent<Spell>();
        if (spell.SpellType == SpellTypes.PROJECTILE)
        {
            spell.transform.position = _projectileSpawnPoint.position;
        }
        else if (spell.SpellType == SpellTypes.AREA_OF_EFFECT)
        {
            
            if (_enemySpawner.Enemies.Count > 0) // If there is at least one active enemy , this is to prevent bugs with the spell spawning
            {
                Enemy enemy = _enemySpawner.Enemies[0].GetComponent<Enemy>();
                spell.transform.position = _enemySpawner.Enemies[0].transform.position;
                enemy.TakeDamage(spell);
            }
            else
            {
                spell.transform.position = _aoeSpawnPoint.position;
            }
        }
    }

    private void OnDisable()
    {
        onSpawnSpell -= CheckSpellCombo;
    }
}
