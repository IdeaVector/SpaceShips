using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    public float speed = 80f;
    public float torqueForce = 10f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

       

            // 5 - Стрельба
            bool shoot = Input.GetButtonDown("Fire1");
            shoot |= Input.GetButtonDown("Fire2");
            // Замечание: Для пользователей Mac, Ctrl + стрелка - это плохая идея

            if (shoot)
            {
                WeaponScript weapon = GetComponent<WeaponScript>();
                if (weapon != null)
                {
                    // ложь, так как игрок не враг
                    weapon.Attack(false);
                }
            }
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
