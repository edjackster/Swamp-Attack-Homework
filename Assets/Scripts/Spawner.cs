using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;
    
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    
    public event Action AllEnemiesSpawned;
    public event Action<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        if(_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;
        
        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveIndex + 1)
                AllEnemiesSpawned?.Invoke();
            _currentWave = null;
        }
    }

    public void NextWave()
    {
        _currentWaveIndex++;
        SetWave(_currentWaveIndex);
        _spawned = 0;
    }

    private void InstantiateEnemy()
    {
        var enemy = Instantiate(_currentWave.Prefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDied;
    }

    private void SetWave(int index)
    {
        _currentWaveIndex = index;
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDied;
        _player.AddMoney(enemy.Reward);
    }
}
