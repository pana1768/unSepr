using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using KnightAdventures.Utils;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7.0f;
    [SerializeField] private float roamingDistanceMin = 3.0f;
    [SerializeField] private float roamingTimerMax = 2.0f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingtime;
    private Vector3 roamingPosition;
    private Vector3 startingposition;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        state = startingState;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void Start()
    {
        startingposition = transform.position;
    }

    private enum State
    {
        Idle,
        Roaming
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Idle:
                break;
                case State.Roaming:
                roamingtime -= Time.deltaTime;

                if (roamingtime < 0)
                {
                    Roaming();
                    roamingtime = roamingTimerMax;
                }
                break;
        }
    }

    private void Roaming()
    {
        roamingPosition = GetRoamingPosition();
        navMeshAgent.SetDestination(roamingPosition);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingposition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
    }
}
