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
    private int levelScore = 0;
    private int player1Score = 0;
    private int player2Score = 0;
    private delegate void Level();
    private GameObject spawn = GameObject.FindGameObjectWithTag("EnemySpawnArea");
    Level currentLevel;
    public GameObject spawnBonus;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = Level1;
        NextLevel();
        giveScore(true, 0);
        giveScore(false, 0);
    }

    public void Defeated()
    {
        GameObject spaceBase = GameObject.FindGameObjectWithTag("Base");
        BaseHealthScript baseHealth = spaceBase.GetComponent<BaseHealthScript>();
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy == null && baseHealth.hp > 0)
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
            PlayerPrefs.SetInt("player1", player1Score);
        }
        else
        {
            player2Score += score;
            player2ScoreText.text = player2Score.ToString();
            PlayerPrefs.SetInt("player2", player2Score);
        }
    }

    void NextLevel()
    {
        levelScore++;
        PlayerPrefs.SetInt("level", levelScore);
        spawnBonus.GetComponent<BonusSpawn>().spawnBonus();
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
    }
    void Level1()
    {
        for (int i = 0; i < 2; i ++)
        {
            Spawn(enemyPrefab);
        }

        levelText.text = "Level №1";
        currentLevel = Level2;
    }

    void Level2()
    {
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
        currentLevel = GameOver;
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("level", levelScore-1);
        SceneManager.LoadScene("EndGame");
    }
}
