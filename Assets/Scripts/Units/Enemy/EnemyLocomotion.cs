using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyLocomotion : MonoBehaviour
{
    [Header("Bool?")]
    public bool targetChasing;
    
    [Header("Components")]
    [SerializeField] private Enemy _enemy;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    [Header("Targets")]
    [SerializeField] private Transform _target;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        if (_target == null)
        {
            _target = FindObjectOfType<Player>().transform;
        }
    }

    private void FixedUpdate()
    {
        if (targetChasing == true) 
        {
            _navMeshAgent.destination = _target.position;
        }
    }
}
