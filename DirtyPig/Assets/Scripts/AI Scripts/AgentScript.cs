using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    [HideInInspector] public bool IsAngry = false;

    [SerializeField] private Transform _target;

    [Header("Patrolling Settings")]
    
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private float _patrollingSpeed;
    [SerializeField] private bool _patrollingEnabled;

    [Header("Chasing Settings")]

    [SerializeField] private float _chasingDistance;
    [SerializeField] private float _chasingSpeed; 
    [SerializeField] private bool _chasingEnabled;
    

    private NavMeshAgent _agent;
    private int _currentTarget = 0;

    private void PatrollingArea()
    {
        _agent.speed = _patrollingSpeed;
        _agent.SetDestination(_targets[_currentTarget].position);
        if (Vector3.Distance(_agent.transform.position, _agent.pathEndPosition) <= 0.8f)
        {
            TargetUpdate();
        }

    }

    private void TargetUpdate()
    {
        _currentTarget = Random.Range(0, _targets.Count);
    }

    private void ChasingTarget()
    {

        if (Vector3.Distance(_agent.transform.position, _target.position) <= _chasingDistance)
        {
            _agent.SetDestination(_target.position);
            _agent.speed = _chasingSpeed;
            IsAngry = true;
        }
        if (Vector3.Distance(_agent.transform.position, _target.position) > _chasingDistance)
        {
            IsAngry = false;
        }
    }
   
    private void Awake() 
    {
        _target = GameObject.FindGameObjectWithTag("PlayerTag").transform;

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (_chasingEnabled)
        {
            ChasingTarget();
        }
        if (_patrollingEnabled && IsAngry == false)
        {
            PatrollingArea();
        }
        
    }
}
