using UnityEngine;
using Game.Data;

namespace Game.View
{
    public class Win : MonoBehaviour
    {
        [SerializeField] private GameRules _rules;
        [SerializeField] private Source _source;
        [SerializeField] private Canvas _canvas;

        private int _coinscoinsCollected;

        private void OnEnable() => _rules.CoinsUp += CoinsUp;
        private void OnDisable() => _rules.CoinsUp -= CoinsUp;
        private void CoinsUp(int coins) => _canvas.enabled = ++_coinscoinsCollected == _source.MaxCoins;
    }
}