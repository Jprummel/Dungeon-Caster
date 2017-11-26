using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private List<GameObject> _enemies = new List<GameObject>();
    private int _maxWaves;
    [SerializeField] private List<int> _waveEnemyAmount = new List<int>();
    [SerializeField] private List<GameObject> _enemyTypesToSpawn = new List<GameObject>();
    private bool _canSpawn;
    [SerializeField]private float _spawnInterval = 0.2f;
    private int _currentWave;
    private int _enemiesToSpawn;
    private bool _dungeonCompleted;

    public int CurrentWave
    {
        get { return _currentWave; }
        set { _currentWave = value; }
    }

    public int MaxWaves
    {
        get { return _maxWaves; }
        set { _maxWaves = value; }
    }

    public int EnemiesToSpawn
    {
        get { return _enemiesToSpawn; }
        set { _enemiesToSpawn = value; }
    }

    public List<GameObject> Enemies
    {
        get { return _enemies; }
        set { _enemies = value; }
    }

    public bool DungeonCompleted
    {
        get { return _dungeonCompleted; }
        set { _dungeonCompleted = value; }
    }

    void Start () {
        _maxWaves = _waveEnemyAmount.Count; //The amount of waves is equal to the number of waves that are filled in in the list
        StartNextWave();
        _canSpawn = true;
	}
	
	void Update () {
        SpawnEnemy();
        if (!GameState.IsPaused)
        {
            _spawnInterval -= Time.deltaTime;
        }
        CheckForDungeonComplete();
	}

    void SpawnEnemy()
    {

        if (_enemiesToSpawn > 0 && _spawnInterval <= 0 && _canSpawn)
        {
            int randomEnemy = Random.Range(0, _enemyTypesToSpawn.Count);
            GameObject enemy = Instantiate(_enemyTypesToSpawn[randomEnemy]);
            enemy.transform.position = this.transform.position; // This object is also the spawn point for the enemies
            _spawnInterval = 2.6f;
            _enemiesToSpawn--;
            
        }
        if (_enemiesToSpawn <= 0 && _enemies.Count == 0)
        {
            _canSpawn = false;
        }
    }

    void CheckForDungeonComplete()
    {
        if(_currentWave == _maxWaves && _enemiesToSpawn <= 0 && _enemies.Count == 0) //If its the last wave and all enemies have been defeated
        {
            DungeonComplete.onDungeonCompleted();
            //_dungeonCompleted = true;
        }
    }

    public void StartNextWave()
    {
        if(_currentWave < _maxWaves)
        {
            _spawnInterval = 2.0f;
            _enemiesToSpawn = _waveEnemyAmount[_currentWave];
            _currentWave += 1;
            ShowDungeonWave.onWaveChange(_currentWave, _maxWaves);
            _canSpawn = true;
        }
    }
}