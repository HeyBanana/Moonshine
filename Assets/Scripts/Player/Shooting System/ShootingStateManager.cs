using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStateManager : MonoBehaviour
{
    [SerializeField] Gun gun; 

    PlayerInputActions action;
    PlayerInputActions.PlayerActions player;

    private void Awake()
    {
        action = new PlayerInputActions();
        player = action.Player;

        player.Shoot.started += _ => gun.isShooting = true;
        player.Shoot.canceled += _ => gun.isShooting = false;
        player.Reload.performed += _ => gun.Reload();
        player.Reload.canceled += _ => gun.Reload();


    }
    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }
}
