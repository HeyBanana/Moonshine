using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimationContoller : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        // Подписываемся на событие стрельбы
        
        Gun.OnShoot += PlayShootAnimation;
    }

    private void OnDestroy()
    {
        // Важно отписаться при уничтожении объекта, чтобы избежать утечек памяти
        Gun.OnShoot -= PlayShootAnimation;
    }

    private void PlayShootAnimation()
    {
        // Воспроизведение анимации стрельбы
        animator.SetBool("Shooting", true);
    }
    public void StopShooting()
    {
        animator.SetBool("Shooting", false);
    }
}
