using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProgression : MonoBehaviour
{

    public delegate void MapProgressionEvent();
    public static MapProgressionEvent onMapProgression;
    public static MapProgressionEvent onStopMapProgression;

    [SerializeField] private List<Transform> _waypoints = new List<Transform>();
    private EnemySpawner _enemySpawner;
    private MoveObject _move;
    private Transform _playerObject;
    private int _area = 0;
    private bool _moving;

    private void Awake()
    {
        _playerObject = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Transform>();
        _enemySpawner = GameObject.FindGameObjectWithTag(Tags.ENEMYSPAWNER).GetComponent<EnemySpawner>();
        _move = GetComponent<MoveObject>();
        _move.CanMove = false;
    }

    void Update()
    {
        if (_enemySpawner.EnemiesToSpawn <= 0 && _enemySpawner.Enemies.Count <= 0)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (!GameState.IsGameOver)
        {
            if (_enemySpawner.CurrentWave < _enemySpawner.MaxWaves)
            {
                float distance = Vector3.Distance(_playerObject.position, _waypoints[_area].position);
                if (distance > 0.2f)
                {
                    StartCoroutine(StartWalkRoutine());
                }
                else
                {
                    _move.CanMove = false;
                    onStopMapProgression();
                    if (_area < _waypoints.Count)
                    {
                        _area++;
                    }
                    _enemySpawner.StartNextWave();
                    _moving = false;
                }
            }
        }
    }

    IEnumerator StartWalkRoutine()
    {
        if (_enemySpawner.CurrentWave < _enemySpawner.MaxWaves && !_moving)
        {
            _moving = true;
            yield return new WaitForSeconds(1.5f);
            onMapProgression();
            _move.CanMove = true;
        }
    }
}
