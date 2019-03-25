using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    public float speed = 80f;
    public float torqueForce = 10f;
    public GameObject player;
    private KeyCode shotButton;
    private KeyCode UpButton;
    private KeyCode DownButton;
    private string horizontal;
    private Rigidbody2D rb;
    void Awake()
    {
       if (player.name == "Player1")
        {
            shotButton = KeyCode.Keypad5;
            UpButton = KeyCode.UpArrow;
            DownButton = KeyCode.DownArrow;
            horizontal = "p1";
        }
        if (player.name == "Player2")
        {
            shotButton = KeyCode.G;
            UpButton = KeyCode.W;
            DownButton = KeyCode.S;
            horizontal = "p2";
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

       

            // 5 - Стрельба
            bool shoot = Input.GetKeyDown(shotButton);
            //shoot |= Input.GetButtonDown("Fire2");
            // Замечание: Для пользователей Mac, Ctrl + стрелка - это плохая идея

            if (shoot)
            {
                WeaponScript weapon = player.GetComponent<WeaponScript>();
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
            rb.AddForce(player.transform.up * speed);
        }

        if (Input.GetKey(DownButton))
        {
            rb.AddForce(player.transform.up * (-1) * speed);
        }
        rb.AddTorque( (-1) * Input.GetAxis(horizontal) * torqueForce);
    }
}
