using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : CharacterShootingState
{
    //References
    private EnemyController m_EnemyController;

    private GameObject characterReference;
    private Vector3 aimVector;
    private void Awake()
    {
        m_EnemyController = GetComponent<EnemyController>();
    }

    private void Start()
    {
        characterReference = FindObjectOfType<CharacterController>().gameObject;
    }

    private new void OnEnable()
    {
        base.OnEnable();
        if(m_EnemyController != null)
        {
            m_EnemyController.m_NavMeshAgent.stoppingDistance = 2;
        }
    }

    public new void Update()
    {
        Shoot();
        FollowCharacter();
    }

    private void FollowCharacter()
    {
        m_EnemyController.m_NavMeshAgent.SetDestination(characterReference.transform.position);
        //aimVector = characterReference.transform.position;
        //aimVector.y = gameObject.transform.forward.y;
        //gameObject.transform.LookAt(aimVector);


    }
}
