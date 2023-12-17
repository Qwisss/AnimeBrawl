using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TriggerAttack : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private Player _player;

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        if (_player == null)
        {
            _player = GetComponentInParent<Player>();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");
        Enemy target = other.GetComponent<Enemy>();
        if (target != null)
        {
            if (!_player.PlayerLocomotion.targets.Contains(target))
            {
                _player.PlayerLocomotion.targets.Add(target);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("Trigger Exit");
        Enemy target = other.GetComponent<Enemy>();
        if (target != null)
        {
            _player.PlayerLocomotion.targets.Remove(target);
        }

    }
}