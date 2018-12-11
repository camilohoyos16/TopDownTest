using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    private EnemyController m_EnemyController;

    [SerializeField] private List<GameObject> patrolPoints;
    private GameObject currentPatrolPoint;
    private bool isInAPath;

    private void Start()
    {
        m_EnemyController = GetComponent<EnemyController>();
        isInAPath = false;
    }

    private void OnDisable()
    {
        ArrivedToPatrolPoint();
        StopAllCoroutines();
    }

    private void Update()
    {
        if (!isInAPath)
        {
            MakeAPath();
        }
    }

    private void MakeAPath()
    {
        isInAPath = true;
        int randomIndexPatrolPoint = Random.Range(0, patrolPoints.Count);
        m_EnemyController.m_NavMeshAgent.stoppingDistance = 0;
        currentPatrolPoint = patrolPoints[randomIndexPatrolPoint];
        m_EnemyController.m_NavMeshAgent.SetDestination(currentPatrolPoint.transform.position);
        patrolPoints.RemoveAt(randomIndexPatrolPoint);
        StartCoroutine(WaitToEndPath());
    }

    IEnumerator WaitToEndPath()
    {
        yield return new WaitWhile(() => m_EnemyController.m_NavMeshAgent.remainingDistance > 1);
        ArrivedToPatrolPoint();
    }

    private void ArrivedToPatrolPoint()
    {
        patrolPoints.Add(currentPatrolPoint);
        isInAPath = false;
    }

}
