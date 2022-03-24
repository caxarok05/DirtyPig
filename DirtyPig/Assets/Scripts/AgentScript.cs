using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private NavMeshAgent agent;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("PlayerTag").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(_target.position);
    }
}
