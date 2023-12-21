
using UnityEngine;

public interface IDamageable 
{
    public int Health { get; set; }

    public void TakeDamage(int damageValue) { }

    Transform GetTransform();

    public void Die() { }
}
