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
    public Text player1ScoreText;
    public Text player2ScoreText;
    private int enemyCount;
    private int player1Score = 0;
    private int player2Score = 0;
    private delegate void Level();
    private GameObject spawn = GameObject.FindGameObjectWithTag("EnemySpawnArea");
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

    public void giveScore(bool toPlayer1, int score)
    {
        if (toPlayer1)
        {
            player1Score += score;
            player1ScoreText.text = player1Score.ToString();
        }
        else
        {
            player2Score += score;
            player2ScoreText.text = player2Score.ToString();
        }
    }

    void NextLevel()
    {
        currentLevel();
    }

    void Spawn(GameObject enemy)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector2 spawnEnemyPosition = new Vector2();
        bool flag = false;
        while (flag == false)
        {
            float randX = Random.Range(-GetComponent<BoxCollider2D>().bounds.size.x / 2, GetComponent<BoxCollider2D>().bounds.size.x / 2);
            spawnEnemyPosition  = new Vector2(randX, transform.position.y - GetComponent<BoxCollider2D>().bounds.size.y);
            flag = true;
            foreach (GameObject cr_enemy in enemies)
            {
                if ((Mathf.Abs(spawnEnemyPosition.x - cr_enemy.transform.position.x) < 2 * enemy.GetComponent<PolygonCollider2D>().bounds.size.x) || (Mathf.Abs(spawnEnemyPosition.y - cr_enemy.transform.position.y) < 2 * enemy.GetComponent<PolygonCollider2D>().bounds.size.x))
                    flag = false;
            }
        }
        Instantiate(enemy, spawnEnemyPosition, Quaternion.identity);
        Debug.Log("spawn");
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
        SceneManager.LoadScene("EndGame");
    }
}
