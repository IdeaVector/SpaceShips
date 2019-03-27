using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text score1;
    public Text score2;
    public Text level;

    void Start()
    {
        score1.text = PlayerPrefs.GetInt("player1").ToString();
        score2.text = PlayerPrefs.GetInt("player2").ToString();
        level.text = PlayerPrefs.GetInt("level").ToString();
    }
}
