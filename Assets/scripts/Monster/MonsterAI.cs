using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

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

    private EventInstance monsterWalk;
    private bool isWalking = false;

    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;
    private bool isChasingPlayer;
    private bool endChassing;
    private float chaseTimer;
    Animator animator;

    [Header("Dead")]
    [SerializeField] Animator ImageDeadAnimator;
    [SerializeField] GameObject screamer;

    private PLAYBACK_STATE playbackstate1;

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
        
        if (!isChasingPlayer)
        {
            Patrol();
            CheckForPlayer();
            UpdateSound();
        }
        else
        {
            ChasePlayer();
            UpdateChaseTimer();
            UpdateSound();
        }
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 1.2f )
        {
            StartCoroutine(PatrolWait());
        }
        else
        {
            animator.SetBool("isRunning", true);
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    IEnumerator PatrolWait()
    {
        animator.SetBool("isRunning", false);

        yield return new WaitForSeconds(patrolWaitTime);

        isChasingPlayer = false;
        isWalking = false;  
        SetPatrolDestination();
    }

    void SetPatrolDestination()
    {
        isWalking = true;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        animator.SetBool("isRunning", true);

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Door>())
        {
            Door dr = other.GetComponent<Door>();
            if(dr.getdoorStat() == Door.DoorState.Locked)
            {
                SetPatrolDestination();
            }
            else
            {
                dr.openDoor();
                StartCoroutine(CloseDoor(dr));
            }
        }
    }
    IEnumerator CloseDoor(Door dr)
    {
        yield return new WaitForSeconds(2.5f);
        dr.CloseDoor();
    }
    void ChasePlayer()
    {
        isWalking=true;
        print("Im chassing");

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
    public void UpdateSound()
    {
        monsterWalk.getPlaybackState(out playbackstate1);

        Vector3 currentPosition = this.transform.position;

        if (playbackstate1.Equals(PLAYBACK_STATE.STOPPED))
        {
            Debug.Log("Start sound");
            monsterWalk.set3DAttributes(RuntimeUtils.To3DAttributes(currentPosition));
            monsterWalk.start();
        }
    }

}
