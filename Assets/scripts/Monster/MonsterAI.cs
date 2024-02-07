using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MonsterAI : MonoBehaviour
{
    public Transform[] waypoints;   // List of waypoints for patrolling
    public Transform player;        // Reference to the player
    public float patrolSpeed = 3f;
    public float chaseSpeed = 6f;
    public float patrolWaitTime = 2f;
    public float detectionRange = 10f;
    public float chaseDuration = 15f;
    public float criticalDistance = 6f; // player dead

    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;
    private bool isChasingPlayer;
    private bool endChassing;
    private float chaseTimer;
    Animator animator;

    [Header("Dead")]
    [SerializeField] Animator ImageDeadAnimator;
    [SerializeField] GameObject screamer;

    public UnityEvent player_dead;
    void Start()
    {
        animator = GetComponent<Animator>();
        player_dead.AddListener(dead);
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetPatrolDestination();
    }
    void dead()
    {
        ImageDeadAnimator.Play("Dead_transition");
        screamer.SetActive(true);
        transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        LightBatterieManager.instance.offLight();
        // diro restart StartCoroutine(RestartGame())
    }
    
    void Update()
    {
        animator.SetBool("isRunning", true);

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
        if (navMeshAgent.remainingDistance < 2f)
        {
            StartCoroutine(PatrolWait());
        }
    }

    IEnumerator PatrolWait()
    {
        yield return new WaitForSeconds(patrolWaitTime);
        isChasingPlayer = false;
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

        if (distanceToPlayer < detectionRange && !endChassing)
        {
            isChasingPlayer = true;
            navMeshAgent.speed = chaseSpeed;
            navMeshAgent.SetDestination(player.position);
            chaseTimer = 0f;
        }
    }

    void ChasePlayer()
    {
        print("Im chassing");
        print(chaseTimer);

        // You can add additional behavior for chasing the player here
        if(Vector3.Distance(transform.position, player.position) <= criticalDistance)
        {
            //eventPlayer death
            player_dead.Invoke();
        }

        if ((!endChassing && chaseTimer >= chaseDuration) || ControlPlayer.playerStat == ControlPlayer.PlayerStat.hiding)
        {
            isChasingPlayer = false;
            endChassing = true;
            print("aaaaaaaaaaaaaaaaaaaaam not chassing");
            StartCoroutine(PatrolWait());
        }
        else
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    void UpdateChaseTimer()
    {
        chaseTimer += Time.deltaTime;
    }
}
