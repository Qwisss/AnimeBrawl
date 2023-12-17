
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : AutoDestroyPoolableObject
{
    [HideInInspector] Rigidbody RigidBody;

    public Vector3 Speed = new Vector3(0, 0, 2);

    public void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    public override void OnEnable()
    {
        base.OnEnable();

        RigidBody.velocity = Speed;
    }

    public override void OnDisable()
    {
        base.OnDisable();

        RigidBody.velocity = Vector3.zero;
    }

}
