using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : AutoDestroyPoolableObject
{
    public Rigidbody RigidBody;

    public float MoveSpeed = 2f;
    public int Damage = 5;
    protected Transform Target;

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    public virtual void Spawn(Vector3 forward, int damage, Transform target)
    {
        Damage = damage;
        Target = target;
        RigidBody.AddForce(forward * MoveSpeed, ForceMode.VelocityChange);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        IDamageable damageable;
        Debug.Log(other);

        if(other.TryGetComponent<IDamageable>(out damageable))
        {
            damageable.TakeDamage(Damage);
        }

        Disable();
    }
    protected void Disable()
    {
        CancelInvoke(DisableMetodName);
        RigidBody.velocity = Vector3.zero;
        gameObject.SetActive(false);

    }

}
