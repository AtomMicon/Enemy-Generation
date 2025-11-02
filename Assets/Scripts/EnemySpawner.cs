using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3[] _spawnPoints;
    [SerializeField] private float _spawnIntervalSec = 2f;
    [SerializeField] private float _spawnHeightOffset = 1f;

    private void Start()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnIntervalSec);
        StartCoroutine(SpawnLoop(waitForSeconds));
    }

    private void OnDrawGizmos()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            DrawSpawnPointGizmos(spawnPoint);
        }
    }

    private void DrawSpawnPointGizmos(Vector3 position)
    {
        float sphereRadius = 0.3f;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(position , sphereRadius);
    }

    private IEnumerator SpawnLoop(WaitForSeconds waitForSeconds)
    {
        while (enabled)
        {
            yield return waitForSeconds;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (_spawnPoints.Length == 0) return;

        Vector3 chosenSpawner = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        Vector3 addHeight = new Vector3(0, _spawnHeightOffset, 0);
        Vector3 spawnPosition = chosenSpawner + addHeight;

        Enemy enemy = Instantiate(_enemyPrefab, chosenSpawner + addHeight, Quaternion.identity);
        enemy.Initialize(RandomDirection());
    }

    private Vector3 RandomDirection()
    {
        float angle = Random.Range(0f, 360f);
        return new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0f, Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
    }
}