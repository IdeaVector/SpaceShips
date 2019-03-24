using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int enemyCount;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject respawns = GameObject.FindGameObjectWithTag("EnemySpawnArea");
            float randX = Random.Range(-GetComponent<BoxCollider2D>().bounds.size.x / 2, GetComponent<BoxCollider2D>().bounds.size.x / 2);
            Vector2 spavnEnemyPosition = new Vector2(randX, transform.position.y - GetComponent<BoxCollider2D>().bounds.size.y);
            Instantiate(enemyPrefab, spavnEnemyPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
