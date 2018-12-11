using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour {

    [SerializeField] private Animator m_Animator;
    private CharacterShootingState m_CharacterShooting;
    private CharacterMovement m_CharacterMovement;

    private void Awake()
    {
        m_CharacterShooting = GetComponent<CharacterShootingState>();
        m_CharacterMovement = GetComponent<CharacterMovement>();
    }

    // Use this for initialization
    void Start () {
        m_CharacterShooting.onStartShooting += StartShootingAnimation;
        m_CharacterShooting.onStopShooting += StopShootingAnimation;
    }

    private void OnDestroy()
    {
        m_CharacterShooting.onStartShooting -= StartShootingAnimation;
        m_CharacterShooting.onStopShooting -= StopShootingAnimation;
    }

    // Update is called once per frame
    void Update () {
        MoveAnimation();
	}

    private void MoveAnimation()
    {
        m_Animator.SetFloat("speed", m_CharacterMovement.MovementVector.magnitude);
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
