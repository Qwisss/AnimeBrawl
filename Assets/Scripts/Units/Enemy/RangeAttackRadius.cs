using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RangeAttackRadius : AttackRadius
{
    public NavMeshAgent Agent;
    public Enemy _enemy;
    public Bullet BulletPrefab;
    public Vector3 BulletSpawnOffset = new Vector3(0, 0.5f, 0);
    public LayerMask Mask;
    private ObjectPool BulletPool;
    [SerializeField] private float SpherecastRadius = 0.1f;
    private RaycastHit Hit;
    private Bullet bullet;
    public new event Action OnDrawArrowBowEvent;
    private IDamageable targetDamageable;
    protected override void Awake()
    {
        base.Awake();

        BulletPool = ObjectPool.CreateInstance(BulletPrefab, Mathf.CeilToInt((1 / AttackCooldown) * BulletPrefab.AutoDestroyTime));
    }

    protected override IEnumerator Attack()
    {
        WaitForSeconds Wait = new WaitForSeconds(AttackCooldown);

        yield return Wait;

        while (Damageables.Count > 0)
        {
            for (int i = 0; i < Damageables.Count; i++)
            {
                if (HasLineOfSightTo(Damageables[i].GetTransform()))
                {
                    targetDamageable = Damageables[i];
                    OnDrawArrowBowEvent?.Invoke();
                    OnAttack?.Invoke(Damageables[i]);
                    _enemy.animator.CrossFade(_enemy.AnimBase.DrawArrowBow, 0.1f);
                    Agent.enabled = false;
                    break;
                }
            }

            if (targetDamageable != null)
            {
                PoolableObject poolableObject = BulletPool.GetObject();
                if (poolableObject != null)
                {
                    bullet = poolableObject.GetComponent<Bullet>();
                    bullet.Damage = Damage;
                    bullet.transform.position = transform.position + BulletSpawnOffset;
                    bullet.RigidBody.AddForce(Agent.transform.forward * BulletPrefab.MoveSpeed, ForceMode.VelocityChange);
                }
            }
            else
            {
                Agent.enabled = true;
            }

            yield return Wait;

            if(targetDamageable == null || !HasLineOfSightTo(targetDamageable.GetTransform()))
            {
                Agent.enabled = true;
            }

            Damageables.RemoveAll(DisabledDamagebles);

        }

        Agent.enabled = true;
        AttackCoroutine = null;
    }

    private bool HasLineOfSightTo(Transform target)
    {
        if(Physics.SphereCast(transform.position + BulletSpawnOffset, SpherecastRadius ,((target.position + BulletSpawnOffset) - (transform.position + BulletSpawnOffset)).normalized, out Hit, SphereCollider.radius, Mask))
        {
            IDamageable damageable;
            if (Hit.collider.TryGetComponent<IDamageable>(out damageable))
            {
                return damageable.GetTransform() == target;
            }

        }

        return false;
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if(AttackCoroutine == null)
        {
            Agent.enabled = true;
        }
    }
}
