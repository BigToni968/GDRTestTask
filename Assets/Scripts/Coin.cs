using UnityEngine;

namespace Game.Gameplay
{
    public class Coin : MonoBehaviour
    {
        private Player _player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _player)) Destroy(gameObject);
        }
    }
}