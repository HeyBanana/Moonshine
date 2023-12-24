using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] string[] _damageTags;
    [SerializeField] int _damage;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var tag in _damageTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                var healthComponent = collision.gameObject.GetComponent<Health>();
                if (healthComponent)
                {
                    healthComponent.Damage(_damage);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var tag in _damageTags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                var healthComponent = other.gameObject.GetComponent<Health>();
                if (healthComponent)
                {
                    healthComponent.Damage(_damage);
                }
            }
        }
    }
}
