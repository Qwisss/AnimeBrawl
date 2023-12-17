using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyLocomotion : MonoBehaviour, IMovable
{
    [Header("Bool?")]
    public bool targetChasing;

    [Header("Animation")]
    [SerializeField] private bool _isRunning;
    protected HashAnimationNames _animBase = new HashAnimationNames();

    [Header("Components")]
    [SerializeField] private Enemy _enemy;
    [SerializeField] public NavMeshAgent NavMeshAgent;

    [Header("Targets")]
    [SerializeField] public Transform Target;
    public float UpdateSpeed = 0.1f;

    [Header("Rotation")]
    private float _rotationSpeed = 1f;
    private Coroutine _lookCoroutine;
    private int TickPerSecond = 60;

    private Coroutine _followCoroutine;


    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();    
    }

    private void Start()
    {
        StartCoroutine(LookAt());
    }

    private void FixedUpdate()
    {
        if (NavMeshAgent.velocity.magnitude > 0.01f && !_isRunning)
        {
            _isRunning = true;
            _enemy.animator.CrossFade(_animBase.Run, 0.1f);
        }
        else if (NavMeshAgent.velocity.magnitude <= 0.01f && _isRunning)
        {
            _isRunning = false;
            _enemy.animator.CrossFade(_animBase.Idle, 0.1f);
        }
    }

    #region Move
    public void StartChasing()
    {
        if (_followCoroutine == null ) 
        {
            _followCoroutine = StartCoroutine(FollowTarget());
        }
        else 
        {
            Debug.LogWarning("Called StartChasing on Enemy that is already chasing! This is likely a bug in some calling class!");
        }
    }

    public void Move()
    {

    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);

        while (enabled)
        {
            if (targetChasing == true)
            {
                NavMeshAgent.SetDestination(Target.transform.position - (Target.transform.position - transform.position).normalized * 0.5f);

                yield return Wait;
            }
        }

    }
    #endregion

    #region Rotation

    private IEnumerator LookAt()
    {

        WaitForSeconds Wait = new WaitForSeconds(1f / TickPerSecond);
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * _rotationSpeed;
        }
        yield return Wait;
    }

    #endregion

    public void OnDisable()
    {
        NavMeshAgent.enabled = false;
    }
}
