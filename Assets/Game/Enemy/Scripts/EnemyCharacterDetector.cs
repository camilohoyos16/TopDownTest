using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterDetector : MonoBehaviour {

    private EnemyStatesManager m_EnemyStatesManager;

    [SerializeField] private LayerMask detectorMask;
    [SerializeField] private float radiusZoneDetectorPatrol;
    [SerializeField] private float radiusZoneDetectorAttacking;
    private float radiusZoneDetector;
    private Collider[] detectedObjects;
    private enemyStates tempState;

    private void Start()
    {
        m_EnemyStatesManager = GetComponent<EnemyStatesManager>();
        radiusZoneDetector = radiusZoneDetectorPatrol;
    }

    private void Update()
    {
       Patrol();
    }

    private void Patrol()
    {
        tempState = enemyStates.patrol;
        detectedObjects = Physics.OverlapSphere(transform.position, radiusZoneDetector, detectorMask);
        if(detectedObjects.Length != 0)
        {
            for (int i = 0; i < detectedObjects.Length; i++)
            {
                if (detectedObjects[i].tag.Equals("Player"))
                {
                    radiusZoneDetector = radiusZoneDetectorAttacking;
                    tempState = enemyStates.attacking;
                }
                else {
                }
            }
        }
        else
        {
            radiusZoneDetector = radiusZoneDetectorPatrol;
        }
        m_EnemyStatesManager.ChangeState(tempState);
    }

}
