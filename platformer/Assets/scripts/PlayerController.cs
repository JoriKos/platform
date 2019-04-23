using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; //snelheid
    public float jumpForce; // de springkracht
    private bool checkReached; //checkpoint reached

    bool isJumping; // boolean om te checken of het karakter al aan het springen is
    Rigidbody2D rb;
    Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        checkReached = false;// aan begin van het level word false gezet
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
        }
        if (col.gameObject.CompareTag("Enemy")) //Als een enemy word aangeraakt
        {
            Reset();
        }
        if (col.gameObject.CompareTag("Checkpoint"))
        {
            startPosition = transform.position;
        }

    }
    void Reset()
    {
        transform.position = startPosition;
    }
}