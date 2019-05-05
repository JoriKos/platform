using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    int rn; //rn = Random Number
    bool reverse; //does enemy reverse?
    bool start; //is game started? Always true
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        start = true;
    }

    void Update()
    {
        AI();
    }
    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void AI()
    {
        while(start)
        {
            rn = Random.Range(0, 10);
            if (0 == rn % 2)
            {
                rb.AddForce(new Vector2(rb.velocity.x, rb.velocity.y));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) // methode om te kijken of karakter iets aanraakt
    {
        if (col.gameObject.CompareTag("Ground")) // kijkt of karakter iets aanraakt met de tag "Ground"
        {
            rb.velocity = Vector2.zero;
        }
    }
    }
