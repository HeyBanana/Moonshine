using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    [SerializeField] float timeToDestroy = 10f;
    Animator animator;

    public int CurrentHeath { get; private set; }

    public event Action<int, int> OnDamaged;
    public event Action OnReaction;
    public event Action<int> OnScoreChanged;

    //public GameBehavior gameBehavior;

    void Awake()
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

        OnDamaged?.Invoke(CurrentHeath, _maxHealth);
        OnReaction?.Invoke();

        if (CurrentHeath <= 0)
        {
            OnDie();
        }

    }

    void OnDie()
    {
        if (gameObject.tag == "Player")
        {
            //gameBehavior.lossButton.gameObject.SetActive(true);

            //gameBehavior.UpdateScene("You want another life with that?");
        }
        else
        {
            animator.SetTrigger("die");
            Destroy(gameObject, timeToDestroy);
            OnScoreChanged?.Invoke(100);
        }
    }
}
