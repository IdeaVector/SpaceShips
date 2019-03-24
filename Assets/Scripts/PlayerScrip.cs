﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    public float speed = 500f;
    public Vector2 speedForce;
    public float torqueForce = -1f;
    public Vector2 movement;
    public Rigidbody2D rb;
    private int UpArrow = 1;
    private int DownArrow;
    private int RigthArrow;
    private int LeftArrow;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(transform.up * (-1) * speed);
        }
        rb.AddTorque( (-1) * Input.GetAxis("Horizontal") * torqueForce);
    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }
}
