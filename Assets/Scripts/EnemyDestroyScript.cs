using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyScript : MonoBehaviour
{
    public int score = 100;
    private SpawnEnemy enemySpawn;
    private bool isFromPlayer1;

    public void setFromPlayer1(bool value)
    {
        isFromPlayer1 = value;
        enemySpawn.giveScore(isFromPlayer1, score);
    }

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
