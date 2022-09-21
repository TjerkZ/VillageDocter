using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject enemy;
    
    void Update()
    {
        StartCoroutine(SpawnOnTime(1));
    }

    public void Spawnenemy()
    {
        int rnd = Random.Range(0, enemySpawnPoints.Length - 1);
        Instantiate(enemy, enemySpawnPoints[rnd]);
    }

    private IEnumerator SpawnOnTime(float waitTime)
    {
        Spawnenemy();
        Debug.Log("Hey");
        yield return new WaitForSeconds(waitTime);
    }
}
