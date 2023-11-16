using UnityEngine;

public class Zombie : Enemy
{

    public override void Attack()
    {
        base.Attack();

        print("Attack Zombie");
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(10);
        }
    }

}
