using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private float _spawnDelay;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned = 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        foreach (Wave wave in _waves)
        {
            if (wave.Spawner != null)
                Gizmos.DrawWireSphere(wave.Spawner.position, wave.SpawnRadius);
        }
    }

    private void Start()
    {
        SetCurrentWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null) 
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _spawnDelay)
        {
            InstantiateZombie();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_spawned >= _currentWave.SpawnCount)
            _currentWave = null;
    }

    public void NextWave()
    {
        SetCurrentWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void InstantiateZombie()
    {
        Zombie zombie = Instantiate(_currentWave.Zombie, GetRandomSpawnPosition(), Quaternion.identity);
        zombie.Init(_player);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float x = UnityEngine.Random.Range(0, _currentWave.SpawnRadius);
        float z = MathF.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(_currentWave.SpawnRadius, 2));

        return _currentWave.Spawner.position + new Vector3(x, 0, z) * UnityEngine.Random.Range(-0.5f, 0.5f);
    }

    private void SetCurrentWave(int waveNumber)
    {
        _currentWave = _waves[waveNumber];
    }
}

[Serializable]
public class Wave
{
    public Zombie Zombie;
    public Transform Spawner;
    public float SpawnRadius;
    public int SpawnCount;
}
