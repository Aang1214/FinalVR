using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterFire : MonoBehaviour
{
    public ParticleSystem FirePrefab;
    public Transform[] spawnPoints;

    public float numberOfFires;
    public int spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFires());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        
        
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        ParticleSystem fire = Instantiate(FirePrefab, spawnPoint.position, spawnPoint.rotation);
        

       


    }
    IEnumerator SpawnFires()
    {
        for (int i = 0; i < numberOfFires; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }


}