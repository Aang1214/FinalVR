using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public int neumberOfEnemies;
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        NavMeshAgent navMeshAgent = enemy.GetComponent<NavMeshAgent>();
        navMeshAgent.Warp(spawnPoint.position);


    }
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < neumberOfEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
