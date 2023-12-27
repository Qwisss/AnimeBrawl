using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private InputController InputController;



    [Header("Stats")]
    [Header("Move")]
    private float _speed;
    private float _rotationSpeed;
    private float UpdateRate = 0.1f;

    [SerializeField] private float animationFinishTime = 0.9f;

    public event Action OnIdleEvent;
    public event Action OnMoveEvent;
    public event Action OnAttackEvent;

    private void Awake()
    {
        if (Agent == null)
        {
            Agent = GetComponent<NavMeshAgent>();
        }
    }
    
    private void Start()
    {
        if (InputController == null)
        {
            InputController = GetComponent<InputController>();
        }

        InputController.OnMoveClickEvent += SetDesctination;

    }

    public void SetDesctination(Vector3 destinationPosition)
    {
        if (Agent.SetDestination(destinationPosition))
        {
            OnMoveEvent?.Invoke();
            StartCoroutine(IsDestinationReached());
        }
    }

    private IEnumerator IsDestinationReached()
    {
        while (Agent.velocity.magnitude > 0.1f)
        {
            yield return new WaitForSeconds(UpdateRate);
        }

        OnIdleEvent?.Invoke();
        StopCoroutine(IsDestinationReached());
    }




}
