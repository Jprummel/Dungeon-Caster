using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawning : MonoBehaviour {

    public delegate void SpawnEnemy();
    public static SpawnEnemy onSpawnGecko;
    public static SpawnEnemy onSpawnComododragon;

    private Transform _spawnPoint;
    [SerializeField] private GameObject _gecko;
    [SerializeField] private GameObject _Comododragon;
	// Use this for initialization
	void Awake () {
        _spawnPoint = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).transform;
        onSpawnGecko += SpawnGecko;
        onSpawnComododragon += SpawnComododragon;
	}
	
    void SpawnGecko()
    {
        GameObject gecko = Instantiate(_gecko);
        gecko.transform.position = _spawnPoint.position;
    }

    void SpawnComododragon()
    {
        GameObject comododragon = Instantiate(_Comododragon);
        comododragon.transform.position = _spawnPoint.position;
    }

    private void OnDisable()
    {
        onSpawnGecko -= SpawnGecko;
        onSpawnComododragon -= SpawnComododragon;
    }
}
