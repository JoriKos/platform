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

    // Update is called once per frame
    private void FixedUpdate()
    {
        AI();
    }

    private void AI()
    {
        while (start)
        {
            rn = Random.Range(1, 10);
            if (rn % 2 == 0)
            {
                transform.position = Vector2.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position = -Vector2.right * speed * Time.deltaTime;
            }
        }
    }
}
