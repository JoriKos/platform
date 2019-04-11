using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0)) //Als mouse1 is ingedrukt
        {
            BulletAttack();
        }

    }

    void BulletAttack()
    {
      Rigidbody2D bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody2D; //Maakt nieuwe bullet van bulletPrefab, quaternion.identity = geen rotatie, is perfect gelijk aan de wereld

        bPrefab.AddForce(Vector2.right * 500); //Zet snelheid naar rechts naar 500
    }
}
