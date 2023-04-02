using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAIMovement : MonoBehaviour
{
    [SerializeField] private Transform[] movePositionTransforms;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float detectionRange = 10f;

    private NavMeshAgent navMeshAgent;
    private int currentDestinationIndex = 0;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    private void Update()
    {
        if (InRange())
        {
            ChasePlayer();
        }
        else if (navMeshAgent.remainingDistance < 0.1f)
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        navMeshAgent.destination = movePositionTransforms[currentDestinationIndex].position;
        currentDestinationIndex = (currentDestinationIndex + 1) % movePositionTransforms.Length;
    }

    private bool InRange()
    {
        return Vector3.Distance(transform.position, playerTransform.position) <= detectionRange;
    }

    private void ChasePlayer()
    {
        navMeshAgent.destination = playerTransform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

