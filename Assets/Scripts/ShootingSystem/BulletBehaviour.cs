using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject bullet;
    public float bulletLife = 3;
    private void Awake()
    {
        Destroy(gameObject, bulletLife);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(bullet);

        }
    }
}

