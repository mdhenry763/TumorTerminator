using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class SpermAI : MonoBehaviour
{
    public float patrolSpeed = 2.0f;
    public float patrolWaitTime = 2.0f;

    private NavMeshAgent navMeshAgent;
    private Vector3 patrolDestination;
    private float patrolTimer;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        patrolDestination = GetNewRandomDestination();
        patrolTimer = 0;
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            if (patrolTimer >= patrolWaitTime)
            {
                patrolDestination = GetNewRandomDestination();
                patrolTimer = 0;
            }
            else
            {
                patrolTimer += Time.deltaTime;
            }

            navMeshAgent.speed = patrolSpeed;
            navMeshAgent.SetDestination(patrolDestination);
        }
    }

    Vector3 GetNewRandomDestination()
    {
        float randomX = UnityEngine.Random.Range(-10f, 10f);
        float randomZ = UnityEngine.Random.Range(-10f, 10f);
        return new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
}