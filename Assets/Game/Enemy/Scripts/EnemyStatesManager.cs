﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyStates
{
    idle,
    patrol,
    attacking
}

public class EnemyStatesManager : MonoBehaviour {

    public enemyStates enemyStateViewver;

    private static enemyStates enemyStateCurrent;
    public static enemyStates EnemyStateCurrent
    {
        get { return enemyStateCurrent; }
    }


    [SerializeField] private EnemyAttack m_EnemyAttack;
    [SerializeField] private EnemyPatrol m_EnemyPatrol;

    public Action onStartShooting;
    public Action onEndShooting;

    public AudioSource m_AudioSourceFireVoice;
    public AudioSource m_AudioSourceShooting;



    private void Start()
    {
        ChangeState(enemyStates.patrol);
    }

    private void Update()
    {
        enemyStateViewver = EnemyStateCurrent;
    }

    public void ChangeState(enemyStates newState)
    {
        enemyStateCurrent = newState;
        switch (newState)
        {
            case enemyStates.idle:
                m_EnemyAttack.enabled = false;
                m_EnemyPatrol.enabled = false;
                break;
            case enemyStates.patrol:
                m_AudioSourceShooting.Stop();
                if (onEndShooting != null)
                {
                    onEndShooting();
                }
                m_EnemyAttack.enabled = false;
                m_EnemyPatrol.enabled = true;
                break;
            case enemyStates.attacking:
                m_AudioSourceFireVoice.Play();
                m_AudioSourceShooting.Play();
                if (onStartShooting != null)
                {
                    onStartShooting();
                }
                m_EnemyAttack.enabled = true;
                m_EnemyPatrol.enabled = false;
                break;
            default:
                break;
        }

    }

}
