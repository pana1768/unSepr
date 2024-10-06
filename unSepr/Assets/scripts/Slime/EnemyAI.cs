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

    private enum State
    {
        Roaming
    }

    private void Update()
    {
        switch (state)
        {
            default:

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
        startingposition = transform.position;
        roamingPosition = GetRoamingPosition();
        ChangeFacingDirection(startingposition, roamingPosition);
        navMeshAgent.SetDestination(roamingPosition);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingposition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
    }


    private void ChangeFacingDirection(Vector3 sourcePosition, Vector3 targetPosition)
    {
        if(sourcePosition.x > targetPosition.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
