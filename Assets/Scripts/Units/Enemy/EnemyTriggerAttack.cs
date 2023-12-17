using UnityEngine;

public class EnemyTriggerAttack : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        if (_enemy == null)
        {
            _enemy = GetComponentInParent<Enemy>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            _enemy.IsAttack = true;
            _enemy.Attack(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("Trigger Exit");
        _enemy.IsAttack = false;
        _enemy.Attack(null);
    }
}
