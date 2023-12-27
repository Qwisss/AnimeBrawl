using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackRadius : MonoBehaviour
{
   /* public SphereCollider SphereCollider;
    protected List<IDamageable> Damageables = new List<IDamageable>();
    public int Damage = 10;
    public float AttackCooldown = 1.0f;
    public event Action OnDrawArrowBowEvent;

    public AttackEvent OnAttack;
    protected Coroutine AttackCoroutine;
    public delegate void AttackEvent(IDamageable Target);

    protected virtual void Awake()
    {
        SphereCollider = GetComponent<SphereCollider>();
    }

    public void SetupConfiguration(float attackRadius, int attackDamage, float attackCooldown)
    {
        SphereCollider.radius = attackRadius;
        Damage = attackDamage;
        AttackCooldown = attackCooldown;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        IDamageable dabageble = other.GetComponent<IDamageable>();
        if (dabageble != null)
        {
            Damageables.Add(dabageble);

            if (AttackCoroutine == null)
            {
                AttackCoroutine = StartCoroutine(Attack());
            }           
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Damageables.Remove(damageable);
            if (Damageables.Count == 0)
            {
                StopCoroutine(AttackCoroutine);
                AttackCoroutine = null;
            }

        }
    }

    protected virtual IEnumerator Attack()
    {
        WaitForSeconds Wait = new WaitForSeconds(AttackCooldown);

        yield return Wait;

        IDamageable closestDamageble = null;
        float closestDistance = float.MaxValue;

        while (Damageables.Count > 0)
        {
            for(int i = 0; i < Damageables.Count; i++)
            {
                Transform damageableTransform = Damageables[i].GetTransform();
                float distance = Vector3.Distance(transform.position, damageableTransform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestDamageble = Damageables[i];
                }
            }

            if (closestDamageble != null)
            {
                OnAttack?.Invoke(closestDamageble);
                closestDamageble.TakeDamage(Damage);
            }

            closestDamageble = null;
            closestDistance = float.MaxValue;

            yield return Wait;

            Damageables.RemoveAll(DisabledDamagebles);
        }

        AttackCoroutine = null;

    }

    protected bool DisabledDamagebles(IDamageable Damageable)
    {
        return Damageable != null && !Damageable.GetTransform().gameObject.activeSelf;
    }
*/
}
