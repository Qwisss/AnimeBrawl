using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private InteractHandler _interactHandler;
    [SerializeField] private Character _character;

    [SerializeField] private float animationFinishTime = 0.9f;

    public event Action OnIdleEvent;
    public event Action OnMoveEvent;

    private float _default_MoveSpeed = 3.5f;
    private float _current_MoveSpeed;
    private StatsValue _moveSpeed;

    private void Awake()
    {
        if (_agent == null)
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        if (_interactHandler == null)
        {
            _interactHandler = GetComponent<InteractHandler>();
        }
        if (_character == null)
        {
            _character = GetComponent<Character>();
        }
    }
    
    private void Start()
    {
        _moveSpeed = _character.TakeStats(Statistic.MoveSpeed);
        UpdateMoveSpeed();

        _interactHandler.OnTargetEvent += SetDesctination;

    }

    private void Update()
    {
        if(_current_MoveSpeed != _moveSpeed.Float_value)
        {
            _current_MoveSpeed = _moveSpeed.Float_value;
            UpdateMoveSpeed();
        }
    }

    private void UpdateMoveSpeed()
    {
        _agent.speed = _default_MoveSpeed * _moveSpeed.Float_value;
    }

    public void SetDesctination(Vector3 destinationPosition)
    {
        if (_agent.SetDestination(destinationPosition))
        {
            _agent.isStopped = false;
            OnMoveEvent?.Invoke();
            StartCoroutine(IsDestinationReached());
        }
    }

    public void StopDestination()
    {
        _agent.isStopped = true;
    }

    private IEnumerator IsDestinationReached()
    {
        while (_agent.velocity.magnitude > 0.1f)
        {
            yield return new WaitForSeconds(DataConfig.UpdateRate);
        }

        OnIdleEvent?.Invoke();
        StopCoroutine(IsDestinationReached());
    }




}
