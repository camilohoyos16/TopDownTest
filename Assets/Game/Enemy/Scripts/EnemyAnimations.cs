using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {

    [SerializeField] private Animator m_Animator;
    private EnemyController m_EnemyController;
    private Rigidbody m_RigidBody;
    private EnemyStatesManager m_EnemyStatesManager;

    private void Awake()
    {
        m_EnemyStatesManager = GetComponent<EnemyStatesManager>();
        m_EnemyController = GetComponent<EnemyController>();
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        m_EnemyStatesManager.onStartShooting += StartShootingAnimation;
        m_EnemyStatesManager.onEndShooting += StopShootingAnimation;
    }

    private void OnDestroy()
    {
        m_EnemyStatesManager.onEndShooting -= StopShootingAnimation;
        m_EnemyStatesManager.onStartShooting -= StartShootingAnimation;
    }

    // Update is called once per frame
    void Update () {
        MoveAnimation();

    }

    private void MoveAnimation()
    {
        m_Animator.SetFloat("speed", m_EnemyController.m_NavMeshAgent.velocity.magnitude);
    }

    private void StartShootingAnimation()
    {
        m_Animator.SetLayerWeight(1, 1f);
    }

    private void StopShootingAnimation()
    {
        m_Animator.SetLayerWeight(1, 0f);
    }
}
