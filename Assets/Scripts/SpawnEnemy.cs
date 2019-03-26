using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public Text levelText;
    private int enemyCount;
    private delegate void Level();
    Level currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = Level1;
        NextLevel();
    }

    public void Defeated()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            NextLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextLevel()
    {
        currentLevel();
    }

    void Spawn(GameObject enemy)
    {
        GameObject respawns = GameObject.FindGameObjectWithTag("EnemySpawnArea");
        float randX = Random.Range(-GetComponent<BoxCollider2D>().bounds.size.x / 2, GetComponent<BoxCollider2D>().bounds.size.x / 2);
        Vector2 spawnEnemyPosition = new Vector2(randX, transform.position.y - GetComponent<BoxCollider2D>().bounds.size.y);
        Instantiate(enemy, spawnEnemyPosition, Quaternion.identity);
    }

    void Level1()
    {
        enemyCount = 2;

        for (int i = 0; i < enemyCount; i ++)
        {
            Spawn(enemyPrefab);
        }

        levelText.text = "Level №1";
        currentLevel = Level2;
    }

    void Level2()
    {
        enemyCount = 4;

        for (int i = 0; i < 2; i++)
        {
            Spawn(enemyPrefab);
        }

        for (int i = 0; i < 2; i++)
        {
            Spawn(enemy1Prefab);
        }

        levelText.text = "Level №2";
        currentLevel = Level3;
    }

    void Level3()
    {
        enemyCount = 6;

        for (int i = 0; i < 2; i++)
        {
            Spawn(enemyPrefab);
        }

        for (int i = 0; i < 2; i++)
        {
            Spawn(enemy1Prefab);
        }

        for (int i = 0; i < 2; i++)
        {
            Spawn(enemy2Prefab);
        }

        levelText.text = "Level №3";
        currentLevel = Level4;
    }

    void Level4()
    {
        enemyCount = 6;

        for (int i = 0; i < 2; i++)
        {
            Spawn(enemy1Prefab);
        }

        for (int i = 0; i < 2; i++)
        {
            Spawn(enemy2Prefab);
        }

        for (int i = 0; i < 2; i++)
        {
            Spawn(enemy3Prefab);
        }

        levelText.text = "Level №4";
        currentLevel = Win;
    }

    void Win()
    {
        SceneManager.LoadScene("Menu");
    }
}
