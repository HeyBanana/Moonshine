using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _score = 100;

    [SerializeField] private float timeToDestroy = 10f;
    private Animator animator;

    public int CurrentHeath { get; private set; }

    public event Action<int, int> OnDamaged;
    public event Action OnReaction;
    public event Action OnDieBecome;
    public event Action<int> OnScoreChanged;

    //public GameBehavior gameBehavior;

    private void Awake()
    {
        CurrentHeath = _maxHealth;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Damage(int damage)
    {
        CurrentHeath -= damage;

        if (CurrentHeath < 0)
        {
            CurrentHeath = 0;
        }

        OnDamaged?.Invoke(CurrentHeath, _maxHealth);

        if (CurrentHeath <= 0)
        {
            OnDie();
        }
        else
        {
            OnReaction?.Invoke(); 

        }

    }

    private void OnDie()
    {
        if (gameObject.tag == "Player")
        {
            //gameBehavior.lossButton.gameObject.SetActive(true);

            //gameBehavior.UpdateScene("You want another life with that?");
        }
        else
        {
            OnDieBecome?.Invoke();
            OnScoreChanged?.Invoke(_score);
            Destroy(gameObject, timeToDestroy);
        }
    }
}
