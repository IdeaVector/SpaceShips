using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyShot = false;
    public bool isPlayer1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }
}
