using System.Collections;
using UnityEngine;

public class Zombie : Enemy
{
    public bool IsCooldown
    {
        get { return _isCooldown; }
        set { _isCooldown = value; }
    }

    public override void Attack(Player target)
    {
        base.Attack(target);

        print("Attack Zombie");
    }
}
