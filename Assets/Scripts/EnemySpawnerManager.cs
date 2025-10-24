using UnityEngine;
using System.Collections;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Spawner[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _spawnHeightOffset = 1f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        if (_spawnPoints.Length == 0) return;

        Spawner chosenSpawner = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        
        Vector3 addHeight = new Vector3(0, _spawnHeightOffset, 0);
        Vector3 spawnPosition = chosenSpawner.SpawnPosition + addHeight;

        GameObject enemyGO = Instantiate(_enemyPrefab, chosenSpawner.SpawnPosition, Quaternion.identity);

        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.Initialize(chosenSpawner.MoveDirection);
    }
}