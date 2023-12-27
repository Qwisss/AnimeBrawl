using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyLocomotion : MonoBehaviour, IMovable
{
    /*[Header("Components")]
    protected HashAnimationNames _animBase = new HashAnimationNames();
    [SerializeField] private Enemy _enemy;
    [SerializeField] public NavMeshAgent NavMeshAgent;

    [Header("Bool")]
    public bool targetChasing;

    [Header("Animation")]
    [SerializeField] private bool _isRunning;

    [Header("Targets")]
    [SerializeField] public Transform Target;
    public float UpdateSpeed = 0.1f;

    [Header("Rotation")]
    private float _rotationSpeed = 1f;

    private Coroutine _followCoroutine;

    public AttackRadius attackRadius;
    private Coroutine LookCoroutine;
    public bool IsAttack;
    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        attackRadius.OnAttack += OnAttack;
    }

    public void SetupConfiguration(float updateSpeed)
    {
        UpdateSpeed = updateSpeed;
    }

*//*    private void FixedUpdate()
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
    }*//*

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
            if (targetChasing == true && NavMeshAgent.enabled)
            {
                NavMeshAgent.SetDestination(Target.transform.position - (Target.transform.position - transform.position).normalized * 0.5f);

                yield return Wait;
            }
            else
            {
                yield return null;
            }
        }

    }
    #endregion

    #region Rotation


    private IEnumerator LookAt(Transform Target)
    {
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);
        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * 2;
            yield return null;
        }

        transform.rotation = lookRotation;
    }

    #endregion

    #region Attack
    public void OnAttack(IDamageable Target)
    {
        //_enemy.animator.CrossFade(_animBase.HightKick, 0.1f);

        if(LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }
        LookCoroutine = StartCoroutine(LookAt(Target.GetTransform()));

    }

    #endregion
    public void OnDisable()
    {
        NavMeshAgent.enabled = false;
    }*/
}
