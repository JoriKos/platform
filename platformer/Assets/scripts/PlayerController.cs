using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed; //snelheid
    private float jumpForce; // de springkracht
    private bool speedUpgrade; // is speed upgrade opgepakt?
    private bool jumpUpgrade; // is jump upgrade opgepakt?
    private bool checkReached; //checkpoint reached

    bool isJumping; // boolean om te checken of het karakter al aan het springen is
    Rigidbody2D rb;
    Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        checkReached = false; // aan begin van het level word false gezet
        setJump(450);
        setSpeed(5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal"); // A of left = -1, D of rechts = 1
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        Jump();
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) // if statement die checkt of het karakter aan het springen is EN of spatiebalk is ingedrukt
        {
            isJumping = true; // maakt isJumping true omdat er gesprongen word

            rb.AddForce(new Vector2(rb.velocity.x, jumpForce)); // laat springen

        }
    }

    void OnCollisionEnter2D(Collision2D col) // methode om te kijken of karakter iets aanraakt
    {

        if (col.gameObject.CompareTag("Ground")) // kijkt of karakter iets aanraakt met de tag "Ground"
        {
            isJumping = false;

            rb.velocity = Vector2.zero;

            if (isJumping == true || jumpUpgrade == true)
            {
                if (isJumping == false || jumpUpgrade == true)
                {
                    jumpUpgrade = false;
                    setJump(450);
                }
            }
        }
        if (col.gameObject.CompareTag("Enemy")) //Als een enemy word aangeraakt
        {
            Reset();
        }
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Checkpoint")) // Checkt of een checkpoint geraakt is
        {
            checkReached = true;
            startPosition = transform.position; //maakt startpositie de huidige positie
        }
        if (col.gameObject.CompareTag("PickupSpeed"))
        {
            speedUpgrade = true;
            setSpeed(10);
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("PickupJump"))
        {
            jumpUpgrade = true;
            setJump(700);
            Destroy(col.gameObject);
        }
    }

    void Reset()
    {
        transform.position = startPosition; //zet huidige positie naar de startpositie
    }

    void setSpeed(int newSpeed) // setter denk ik maar wat het precies doet weet ik ook niet
    {
        if (newSpeed > 20)
            speed = 20;
        else if (newSpeed <= 4)
        {
            speed = 5;
        }
        else
            speed = newSpeed;
    }
    void setJump(int newJump) // setter denk ik maar wat het precies doet weet ik ook niet
    {
        if (newJump > 700)
            jumpForce = 700;
        else if (newJump <= 450)
        {
            jumpForce = 450;
        }
        else
            jumpForce = newJump;
    }
}