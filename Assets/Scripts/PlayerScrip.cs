using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
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
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");
        movement = new Vector2(
            speed.x * InputX,
            speed.y * InputY);
    }

    private void FixedUpdate()
    {
        rb.velocity = movement;
    }
}
