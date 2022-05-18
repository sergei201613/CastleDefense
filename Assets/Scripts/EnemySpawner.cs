using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _minSpawnDelay = 3f;
    [SerializeField] private float _maxSpawnDelay = 5f;

    private float _spawnDelay;
    private float _lastSpawnTime = 0;
    private int _enemiesSpawned = 0;
    private int _totalEnemiesCount;
    private GameMode _gm;

    private void Start()
    {
        _gm = FindObjectOfType<GameMode>();

        _spawnDelay = Random.Range(_minSpawnDelay, _maxSpawnDelay);
        _totalEnemiesCount = _gm.EnemiesToWin;
    }

    private void Update()
    {
        if (Time.time > _lastSpawnTime + (_spawnDelay))
        {
            for (int i = 0; i < Random.Range(1, 3); i++) Spawn();
        }
    }

    private void Spawn()
    {
        if (_enemiesSpawned >= _totalEnemiesCount) return;

        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        _spawnDelay = Random.Range(_minSpawnDelay, _maxSpawnDelay);
        _lastSpawnTime = Time.time;

        _enemiesSpawned++;
    }
}