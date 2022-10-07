using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public float spawnRate = 5f;
    public GameObject enemyPf;
    public int enemiesToSpawn;
    public float spawnDelay = 5f;
    public float spawnRange = 25f;



    void Start()
    {

        //get 
        // spawn an enemy in random area from this game object
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 currentPosition = transform.position;

            Vector3 spawnPosition = new Vector3(currentPosition.x + Random.Range(-spawnRange, +spawnRange), currentPosition.y + Random.Range(0, spawnRange));
            GameObject enemy = Instantiate(enemyPf, spawnPosition, Quaternion.identity);
            enemy.transform.parent = transform;
        }


    }


}
