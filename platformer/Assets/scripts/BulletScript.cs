using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    void Start()
    { 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
     if (other.gameObject.tag == "Ground") // Als het object gameobject met tag "ground" aanraakt
     {
            Destroy(gameObject); //Destroy bullet
     }
        Physics2D.IgnoreLayerCollision(8,8);

        if (other.gameObject.tag == "bb")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}