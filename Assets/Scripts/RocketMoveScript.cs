using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMoveScript : MonoBehaviour
{
    private Transform enemy;
    private float speed = 4.0f;

    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").transform;
    }

    void Update()
    {
        if (enemy != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy.position, Time.deltaTime * speed);
            Vector3 vectorToTarget = enemy.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle + 270.0F, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
