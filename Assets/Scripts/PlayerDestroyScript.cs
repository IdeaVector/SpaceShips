using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyScript : MonoBehaviour
{
    private void OnDestroy()
    {
        GameObject spawn = GameObject.FindGameObjectWithTag("EnemySpawnArea");
        SpawnEnemy script = spawn.GetComponent<SpawnEnemy>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            script.GameOver();
        }  
    }
}
