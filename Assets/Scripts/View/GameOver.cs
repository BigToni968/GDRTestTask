using Game.Gameplay;
using UnityEngine;

namespace Game.View
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Spawn _spawn;

        private void Start() => _spawn.Player.Dead += Show;

        private void OnDisable() => _spawn.Player.Dead -= Show;
        private void Show() => _canvas.enabled = true;
    }
}