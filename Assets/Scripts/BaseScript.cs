using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScript : MonoBehaviour
{
    void Start()
    {
    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndGame");
    }
}
