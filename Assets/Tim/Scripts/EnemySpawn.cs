using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject enemy;
    [SerializeField] public int ammountOfEnimies = 1;
    
    void Start()
    {
       // StartCoroutine(SpawnOnTime(1));
    }


    public void Spawnenemy()
    {
        int rnd = Random.Range(0, enemySpawnPoints.Length);
        Debug.Log(rnd);
        Instantiate(enemy, enemySpawnPoints[rnd]);
    }

    public void NextWave()
    {
        ammountOfEnimies += 10;
    }

    public IEnumerator SpawnOnTime(float waitTime)
    {
        for (int i = 0; i < ammountOfEnimies; i++)
        {
            Spawnenemy();
            yield return new WaitForSeconds(waitTime);
        }
    }
}
