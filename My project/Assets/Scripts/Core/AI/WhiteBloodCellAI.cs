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
<<<<<<< Updated upstream:My project/Assets/Scripts/Core/AI/AIController.cs
    public float attackCooldown = 2.0f; //Attack cooldown in seconds for enemy.
=======
    public float attackCooldown = 2.0f;
    public int attackDamage = 5;
    public bool isAttacking = false;
>>>>>>> Stashed changes:My project/Assets/Scripts/Core/AI/WhiteBloodCellAI.cs

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
<<<<<<< Updated upstream:My project/Assets/Scripts/Core/AI/AIController.cs
            DealDMG();
=======
            if (isAttacking == false)
            {
                isAttacking = true;
                StartCoroutine(DealDMG());
            }
>>>>>>> Stashed changes:My project/Assets/Scripts/Core/AI/WhiteBloodCellAI.cs
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

    IEnumerator DealDMG()
    {
<<<<<<< Updated upstream:My project/Assets/Scripts/Core/AI/AIController.cs
        yield return new WaitForSeconds(attackCooldown);
=======
        health.TakeDamage(attackDamage);
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
        
>>>>>>> Stashed changes:My project/Assets/Scripts/Core/AI/WhiteBloodCellAI.cs
    }
}