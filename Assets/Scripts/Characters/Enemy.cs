using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected float _attackRange;
    //Health related
    private Healthbar _healthbar;

    private Player _player;
    private Transform _playerObject;
    private MoveObject _move;

    //Animations
    private EnemyAnimations _anims;

    //Rune / spell related
    [SerializeField] protected DamageTypes _weakness;
    protected EnemySpawner _enemySpawner;

    //Collider
    private BoxCollider2D _collider;

    protected override void Awake()
    {
        base.Awake();
        _move = GetComponent<MoveObject>();
        _healthbar = GetComponent<Healthbar>();
        _currentHealth = _maxHealth;
        _anims = GetComponent<EnemyAnimations>();
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Player>();
        _playerObject = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Transform>();
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        _move.MoveSpeed = GameObject.FindGameObjectWithTag(Tags.MAPDIFFICULTYMANAGER).GetComponent<SetMapSpeed>().EnemyMoveSpeed;
        _enemySpawner.Enemies.Add(this.gameObject);
        _collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        ToggleMovement();
        CheckDistanceToPlayer();
    }

    void CheckDistanceToPlayer()
    {
        float distance = Vector2.Distance(this.transform.position, _playerObject.position);
        if (distance <= _attackRange)
        {
            //If the enemy is in attack range, stop moving and attack
            _move.CanMove = false;
            _anims.AttackAnimation();
        }
    }

    public void AttackPlayer()
    {
        //Assign this to a keyframe in the attack animation of the enemy
        _player.TakeDamage();
    }

    IEnumerator TakeDamageRoutine(float stunTime)
    {
        _move.CanMove = false;
        _anims.HitAnimation();
        yield return new WaitForSeconds(stunTime);
        if (_currentHealth > 0)
        {
            _move.CanMove = true; //Enemy can only walk again if he has more than 0 hp / isn't dead
        }
    }

    public void RemoveEnemy()
    {
        //Removes the enemy from the list so it cant be hit anymore
        if (_enemySpawner.Enemies.Contains(this.gameObject))
        {
            _move.CanMove = false;
            _collider.enabled = false;
            _enemySpawner.Enemies.Remove(this.gameObject);
        }
    }

    public void Death()
    {
        //When the enemy's health drops to 0 or when he has attacked the player, call this function
        //If its through attacking the player, assign it to the last keyframe in the attack animation
        _move.CanMove = false;
        _anims.DeathAnimation();
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject); //Destroys the enemy object entirely (Link this function to last frame of Death anim)
    }

    public void ToggleMovement()
    {
        if (GameState.EnemiesPaused || GameState.IsPaused || _currentHealth <= 0)
        {
            _move.CanMove = false;
        }
        else
        {
            _move.CanMove = true;
        }
    }

    public void TakeDamage(Spell spell)
    {
        if (!spell.EnemyHit)
        {
            Vector2 damageTextPos = new Vector2(this.transform.position.x, this.transform.position.y + 2);
            if (spell.SpellDamageType == _weakness)
            {
                //if the damage type of the spell is the same as the weakness of the enemy, do double damage
                _currentHealth -= spell.SpellDamage * 2;
                ShowDamage.onShowDamage(damageTextPos, spell.SpellDamage * 2, true);
                ScreenShake.onScreenShake(4);
            }
            else
            {
                //IF the spells damage type is not the same as the weakness of the enemy, deal normal damage
                _currentHealth -= spell.SpellDamage;
                ShowDamage.onShowDamage(damageTextPos, spell.SpellDamage,false);
                ScreenShake.onScreenShake(1);
            }
            spell.EnemyHit = true; //This is to make sure spells dont hit multiple enemies
            StartCoroutine(TakeDamageRoutine(0.3f));
        }

        _healthbar.ChangeHealth(_currentHealth, _maxHealth);
        if (_currentHealth <= 0)
        {
            Death();
        }
    }
}