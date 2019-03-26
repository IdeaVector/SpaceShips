using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{
    private Transform spaceBase;
    public float speed;
    public float smooth = 2.0F;
    public  int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        Console.Write("Trigerred!");
        spaceBase = GameObject.FindWithTag("Base").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, spaceBase.position, Time.deltaTime * speed);
        Vector3 vectorToTarget = spaceBase.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 90.0F, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }

}
