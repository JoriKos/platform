using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D col) // methode om te kijken of karakter iets aanraakt
    {
        if (col.gameObject.CompareTag("Ground")) // kijkt of karakter iets aanraakt met de tag "Ground"
        {
            rb.velocity = Vector2.zero;
        }
    }
    }
