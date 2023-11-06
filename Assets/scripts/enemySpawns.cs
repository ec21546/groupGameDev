using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawns : MonoBehaviour
{


    public GameObject enemyPrefab;
    public int numberOfEnemies = 5;
    public float spawnRadius = 5f;
    public bool spawnAggressive = false;
    public Transform player;
    public float spawnDistance = 10f;

    private bool spawned = false;


    void Start()
    {
        spawnAggressive = Random.Range(0, 2) == 0;
        numberOfEnemies = Random.Range(3, 5);
    }

    void Update()
    {
        if (ProximityCheck() & !spawned)
        {
            SpawnEnemies();
        }
    }

    bool ProximityCheck()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            return distanceToPlayer <= spawnDistance;
        }
        return true;
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, 0, randomPosition.y);

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.transform.parent = this.transform;


            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.spawnPoint = this.transform;
                enemyMovement.isAggressive = spawnAggressive;
            }
        }
        spawned = true;
    }
}
