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
/*    private float _speed;
    private float _rotationSpeed;*/

    [SerializeField] private float animationFinishTime = 0.9f;

    public event Action OnIdleEvent;
    public event Action OnMoveEvent;

    private void Awake()
    {
        if (Agent == null)
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        if (InputController == null)
        {
            InputController = GetComponent<InputController>();
        }
    }
    
    private void Start()
    {

        InputController.OnMoveClickEvent += SetDesctination;

    }

    public void SetDesctination(Vector3 destinationPosition)
    {
        if (Agent.SetDestination(destinationPosition))
        {
            Agent.isStopped = false;
            OnMoveEvent?.Invoke();
            StartCoroutine(IsDestinationReached());
        }
    }

    public void StopDestination()
    {
        Agent.isStopped = true;
    }

    private IEnumerator IsDestinationReached()
    {
        while (Agent.velocity.magnitude > 0.1f)
        {
            yield return new WaitForSeconds(DataConfig.UpdateRate);
        }

        OnIdleEvent?.Invoke();
        StopCoroutine(IsDestinationReached());
    }




}
