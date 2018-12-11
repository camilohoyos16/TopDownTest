using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    [HideInInspector] public NavMeshAgent m_NavMeshAgent;

    // Use this for initialization
    void Awake () {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
