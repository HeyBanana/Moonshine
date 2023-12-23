using Moonshine.Player.MovementState;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private MovementStateManager movementStateManager;

    private float footStepTimer;

    private Dictionary<float, float> movementTimers;

    private void Awake()
    {
        movementTimers = new Dictionary<float, float>
        {
            { movementStateManager.walkSpeed, .53f },
            { movementStateManager.runSpeed, .35f }
        };
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        footStepTimer -= Time.deltaTime;

        if (footStepTimer < 0f)
        {
            if (movementStateManager.IsInMovement() && movementStateManager.IsGrounded())
            {
                if (movementTimers.ContainsKey(movementStateManager.GetMoveSpeed()))
                {
                    footStepTimer = movementTimers[movementStateManager.GetMoveSpeed()];
                    SoundManager.Instance.PlaySandFootsteps(movementStateManager.transform.position);
                }
            }
        }
    }
}
