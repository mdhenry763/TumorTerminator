using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class WhiteBloodCellAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerHealth health;
    
    public float patrolSpeed = 2.0f;
    public float chaseSpeed = 4.0f;
    public float patrolWaitTime = 2.0f;
    public float chaseRange = 10.0f;
    public float attackRange = 2.0f;
    public float attackCooldown = 2.0f;
    public bool isAttacking = false;
    public int damage = 5;

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
            if (isAttacking == false)
            {
                StartCoroutine(DealDMG());
                isAttacking = true;
            }
        }
        else if (distanceToPlayer < chaseRange)
        {
            Debug.Log("Not In Range");
            isChasing = true;
            navMeshAgent.speed = chaseSpeed;
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            Debug.Log("Not In Range");
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

    IEnumerator DealDMG()
    {
        yield return new WaitForSeconds(attackCooldown);
        health.TakeDamage(damage);
        isAttacking = false;
    }
}