using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyLocomotion))]
[RequireComponent(typeof(HealthSystemBase))]

public abstract class Enemy : PoolableObject
{
    /*[Header("Components")]
    public HashAnimationNames AnimBase = new HashAnimationNames();
    public EnemyScriptableObject EnemyScriptableObject;

    public Animator animator;
    public NavMeshAgent Agent;

    public EnemyLocomotion EnemyLocomotion;
    public EnemyHealthSystem EnemyHealthSystem;
    public AttackRadius AttackRadius;

    private void Awake()
    {
        Iniatialize();
    }

    public virtual void OnEnable()
    {
        SetupAgentFromConfiguration();
    }

    private void Iniatialize()
    {
        EnemyLocomotion.SetupConfiguration(EnemyScriptableObject.AIUpdateInterval);
        EnemyHealthSystem.SetupConfiguration(EnemyScriptableObject.MaxHealth, EnemyScriptableObject.CurrentHealth);
        AttackRadius.SetupConfiguration(EnemyScriptableObject.AttackRadius, EnemyScriptableObject.AttackDamage, EnemyScriptableObject.AttackCooldown);
    }

    public virtual void SetupAgentFromConfiguration()
    {
        Agent.acceleration = EnemyScriptableObject.Acceleration;
        Agent.angularSpeed = EnemyScriptableObject.AngularSpeed;
        Agent.areaMask = EnemyScriptableObject.AreaMask;
        Agent.avoidancePriority = EnemyScriptableObject.AvoidancePriority;
        Agent.baseOffset = EnemyScriptableObject.BaseOffset;
        Agent.height = EnemyScriptableObject.Height;
        Agent.obstacleAvoidanceType = EnemyScriptableObject.obstacleAvoidanceType;
        Agent.radius = EnemyScriptableObject.Radius;
        Agent.speed = EnemyScriptableObject.Speed;
        Agent.stoppingDistance = EnemyScriptableObject.StoppingDistance;
    }
    public override void OnDisable()
    {
        base.OnDisable();

        Agent.enabled = false;
    }*/
}
