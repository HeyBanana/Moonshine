using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform patrolRoute;
    [SerializeField] List<Transform> locations;

    public event Action<int> OnScoreOldVersionChanged;

    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    private int _lives = 3;

    public int EnemyLives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(gameObject);
                OnScoreOldVersionChanged?.Invoke(100);

                Debug.Log("Enemy down.");

            }
        }
    }


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        OnitializePatrolRoute();

        MoveToNextPatrolLocation();
    }

    void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    private void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0) { return; }

        _agent.destination = locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % locations.Count;
    }

    private void OnitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _agent.destination = player.position;
            Debug.Log("Player detected - attack!");
        }

        if (other.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Critical hit!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }

}
