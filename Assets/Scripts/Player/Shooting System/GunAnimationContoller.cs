using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimationContoller : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        // ������������� �� ������� ��������
        
        Gun.OnShoot += PlayShootAnimation;
    }

    private void OnDestroy()
    {
        // ����� ���������� ��� ����������� �������, ����� �������� ������ ������
        Gun.OnShoot -= PlayShootAnimation;
    }

    private void PlayShootAnimation()
    {
        // ��������������� �������� ��������
        animator.SetBool("Shooting", true);
    }
    public void StopShooting()
    {
        animator.SetBool("Shooting", false);
    }
}
