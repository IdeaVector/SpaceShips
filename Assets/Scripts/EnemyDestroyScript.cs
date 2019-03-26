using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyScript : MonoBehaviour
{
    private SpawnEnemy enemySpawn;

    private void Start()
    {
        GameObject enemySpawnArea = GameObject.FindGameObjectWithTag("EnemySpawnArea");
        enemySpawn = enemySpawnArea.GetComponent<SpawnEnemy>();
    }
    
    private void OnDestroy()
    {
        enemySpawn.Defeated();
    }
}
