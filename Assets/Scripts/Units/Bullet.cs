using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : AutoDestroyPoolableObject
{
    public Rigidbody RigidBody;

    public float MoveSpeed = 2f;
    public int Damage = 5;

    public void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable;
        Debug.Log(other);

        if(other.TryGetComponent<IDamageable>(out damageable))
        {
            damageable.TakeDamage(Damage);
        }

        Disable();
    }
    public void Disable()
    {
        CancelInvoke(DisableMetodName);
        RigidBody.velocity = Vector3.zero;
        gameObject.SetActive(false);

    }

}
