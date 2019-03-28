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
    private KeyCode LeftButton;
    private KeyCode RigthButton;
    private string horizontal;
    private bool isPlayer1;
    // Start is called before the first frame update
    void Awake()
    {
        if (this.name == "Player1")
        {
            shotButton = KeyCode.Keypad5;
            UpButton = KeyCode.UpArrow;
            DownButton = KeyCode.DownArrow;
            LeftButton = KeyCode.LeftArrow;
            RigthButton = KeyCode.RightArrow;
            horizontal = "p1_horizontal";
            isPlayer1 = true;
        }
        else if (this.name == "Player2")
        {
            shotButton = KeyCode.G;
            UpButton = KeyCode.W;
            DownButton = KeyCode.S;
            LeftButton = KeyCode.A;
            RigthButton = KeyCode.D;
            horizontal = "p2_horizontal";
            isPlayer1 = false;
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
                    weapon.isPlayer1 = isPlayer1;   
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
        if (Input.GetKey(LeftButton))
        {
            rb.AddTorque(torqueForce);
        }
        if (Input.GetKey(RigthButton))
        {
            rb.AddTorque(-1 * torqueForce);
        }
    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    public void WeaponLevelUp()
    {
        WeaponScript script = GetComponent<WeaponScript>();
        script.LevelUp();
    }
   

}
