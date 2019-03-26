using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    public float speed = 80f;
    public float torqueForce = 10f;
    public Rigidbody2D rb;
    private KeyCode shotButton;
    private KeyCode UpButton;
    private KeyCode DownButton;
    private string horizontal;
    // Start is called before the first frame update
    void Awake()
    {
        if (this.name == "Player1")
        {
            shotButton = KeyCode.Keypad5;
            UpButton = KeyCode.UpArrow;
            DownButton = KeyCode.DownArrow;
            horizontal = "p1_horizontal";
        }
        else if (this.name == "Player2")
        {
            shotButton = KeyCode.G;
            UpButton = KeyCode.W;
            DownButton = KeyCode.S;
            horizontal = "p2_horizontal";
        }

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            bool shoot = Input.GetKeyDown(shotButton);

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
        if (Input.GetKey(UpButton))
        {
            rb.AddForce(transform.up * speed);
        }

        if (Input.GetKey(DownButton))
        {
            rb.AddForce(transform.up * (-1) * speed);
        }
        rb.AddTorque( (-1) * Input.GetAxis(horizontal) * torqueForce);
    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }
}
