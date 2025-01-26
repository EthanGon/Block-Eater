using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float minSpawnTime = 3.0f;
    public float maxSpawnTime = 6.0f;
    public float minSpawnRange;
    public float maxSpawnRange;
    public bool randomX;
    public bool randomY;
    public Vector2 spawnDir;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), Random.Range(minSpawnTime, maxSpawnTime), Random.Range(minSpawnTime, maxSpawnTime));    
    }

    public void SpawnEnemy() 
    {
        if (randomX)
        {
            Enemy enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(minSpawnRange, maxSpawnRange), transform.position.y, transform.position.z), transform.rotation);
            enemy.SetMoveDirection(spawnDir);
        }
        else if (randomY)
        {
            Enemy enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, Random.Range(minSpawnRange, maxSpawnRange), transform.position.z), transform.rotation);
            enemy.SetMoveDirection(spawnDir);
        }
    }

}
