using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{
    private Transform spaceBase;
    private float speed = 2.0f;
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

        Vector3 dir = (spaceBase.position - transform.position).normalized;

        //transform.rotation = Quaternion.Slerp(transform.rotation, spaceBase.position, Time.deltaTime * smooth);

        //transform.rotation = Quaternion.identity;
    }

}
