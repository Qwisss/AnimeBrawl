using UnityEngine;

public class TriggerAttack : MonoBehaviour
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

    private void OnTriggerStay(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            if (_zombie.IsCooldown == false)
            {
                _zombie.Attack(player);
            }
        }
    }
}