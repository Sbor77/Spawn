using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnGenerator : MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;

    [SerializeField] private List<Transform> _spawnPoints;    

    [SerializeField] private int _generationInterval = 2;

    [SerializeField] private int _generationRounds = 3;

    private void Start()
    {        
        StartCoroutine(GenerateEnemy(_generationInterval,_generationRounds));

        StopCoroutine(GenerateEnemy(_generationInterval,_generationRounds));
    }

    private IEnumerator GenerateEnemy(int interval, int rounds)
    {
        var waitForSeconds = new WaitForSeconds(interval);

        for (int j = 0; j < rounds; j++)
        {
            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                Instantiate(_enemyPrefab, new Vector3(_spawnPoints[i].position.x, _spawnPoints[i].position.y, 0), Quaternion.identity);

                yield return waitForSeconds;
            }
        }
    }
}
