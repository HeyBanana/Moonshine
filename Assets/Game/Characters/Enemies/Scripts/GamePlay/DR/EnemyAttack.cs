using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform targer;
    [SerializeField] int damage = 20;

    public event Action OnShoot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackHitEvent()
    {
        if (targer == null) return;
        OnShoot?.Invoke();
        Debug.Log("bang bang");
    }
}
