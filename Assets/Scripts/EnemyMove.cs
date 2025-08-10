using UnityEngine;
using UnityEngine.AI;

public class NavMeshStateMachine : MonoBehaviour
{
    public enum State
    {
        Idle,
        ChasePlayer
    }

    public State currentState = State.Idle;

    private GameObject player;
    private NavMeshAgent agent;

    public float chaseDistance = 15f;
    public float stopChaseDistance = 20f;
    public float navMeshCheckDistance = 2.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        SwitchState(State.Idle);
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        bool playerOnNavMesh = IsPlayerOnNavMesh();

        switch (currentState)
        {
            case State.Idle:
                agent.ResetPath();

                if (playerOnNavMesh && distanceToPlayer < chaseDistance)
                {
                    SwitchState(State.ChasePlayer);
                }
                break;

            case State.ChasePlayer:
                if (playerOnNavMesh && distanceToPlayer < stopChaseDistance)
                {
                    agent.SetDestination(player.transform.position);
                }
                else
                {
                    SwitchState(State.Idle);
                }
                break;
        }
    }

    void SwitchState(State newState)
    {
        currentState = newState;

        if (newState == State.Idle)
        {
            agent.ResetPath();
        }

        if (newState == State.ChasePlayer)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    bool IsPlayerOnNavMesh()
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(player.transform.position, out hit, navMeshCheckDistance, NavMesh.AllAreas);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthSystemForDummies healthSystem = other.GetComponent<HealthSystemForDummies>();
            if (healthSystem != null)
            {
                healthSystem.AddToCurrentHealth(-10);
            }
        }
    }

}


