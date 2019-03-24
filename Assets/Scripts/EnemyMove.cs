using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform spaceBase;
    private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        spaceBase = GameObject.FindWithTag("Base").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, spaceBase.position, Time.deltaTime * speed);
    }
}
