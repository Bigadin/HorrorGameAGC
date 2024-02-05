using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform[] waypoints;   // List of waypoints for patrolling
    public Transform player;        // Reference to the player
    public float patrolSpeed = 3f;
    public float chaseSpeed = 6f;
    public float patrolWaitTime = 2f;
    public float detectionRange = 10f;
    public float chaseDuration = 15f;

    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;
    private bool isChasingPlayer;
    private float chaseTimer;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetPatrolDestination();
    }

    void Update()
    {
        if (!isChasingPlayer)
        {
            Patrol();
            CheckForPlayer();
        }
        else
        {
            ChasePlayer();
            UpdateChaseTimer();
        }
    }

    void Patrol()
    {
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            StartCoroutine(PatrolWait());
        }
    }

    IEnumerator PatrolWait()
    {
        yield return new WaitForSeconds(patrolWaitTime);
        SetPatrolDestination();
    }

    void SetPatrolDestination()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        navMeshAgent.speed = patrolSpeed;
    }

    void CheckForPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            isChasingPlayer = true;
            navMeshAgent.speed = chaseSpeed;
            navMeshAgent.SetDestination(player.position);
            chaseTimer = 0f;
        }
    }

    void ChasePlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // You can add additional behavior for chasing the player here

        if (distanceToPlayer > detectionRange * 1.5f || chaseTimer >= chaseDuration)
        {
            isChasingPlayer = false;
            SetPatrolDestination();
        }
    }

    void UpdateChaseTimer()
    {
        chaseTimer += Time.deltaTime;
    }
}
