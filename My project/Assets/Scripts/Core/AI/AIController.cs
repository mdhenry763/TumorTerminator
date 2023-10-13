using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    public float patrolSpeed = 2.0f;
    public float chaseSpeed = 4.0f;
    public float patrolWaitTime = 2.0f;
    public float chaseRange = 10.0f;
    public float attackRange = 2.0f;

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private Vector3 patrolDestination;
    private float patrolTimer;
    private bool isChasing;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Make sure your player has the tag "Player".
        navMeshAgent = GetComponent<NavMeshAgent>();
        patrolDestination = GetNewRandomDestination();
        patrolTimer = 0;
        isChasing = false;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < attackRange)
        {
            // Attack the player (implement your attack logic here).
            // Call IEnumerable "dealDMG" with reference to health - similar to how it's done elsewhere.
        }
        else if (distanceToPlayer < chaseRange)
        {
            isChasing = true;
            navMeshAgent.speed = chaseSpeed;
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            isChasing = false;

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
    }

    Vector3 GetNewRandomDestination()
    {
        float randomX = UnityEngine.Random.Range(-10f, 10f);
        float randomZ = UnityEngine.Random.Range(-10f, 10f);
        return new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
}