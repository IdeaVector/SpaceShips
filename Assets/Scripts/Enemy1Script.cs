﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponScript weapon = GetComponent<WeaponScript>();
        if (weapon != null)
        {
            weapon.Attack(true);
        }
    }
}
