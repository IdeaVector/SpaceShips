using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Script : MonoBehaviour
{
    public GameObject enemy;
    public float spawnCooldown = 2.0f;
    private float currentCooldown;
    
    void Start()
    {
        currentCooldown = spawnCooldown;
    }
    
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        currentCooldown = spawnCooldown;
    }
}
