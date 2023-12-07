using UnityEngine;

public class EnemyTriggerAttack : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Zombie _zombie;

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        if (_zombie == null)
        {
            _zombie = GetComponentInParent<Zombie>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            _zombie.IsAttack = true;
            _zombie.Attack(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("Trigger Exit");
        _zombie.IsAttack = false;
        _zombie.Attack(null);
    }
}
