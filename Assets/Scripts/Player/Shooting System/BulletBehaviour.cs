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
            var enemy = collision.gameObject.GetComponent<Health>();
            enemy.Damage(25);
            Destroy(collision.gameObject);
            Destroy(bullet);

        }
    }
}

