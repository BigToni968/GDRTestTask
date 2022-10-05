using UnityEngine;
using System;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/" + nameof(GameRules), fileName = nameof(GameRules))]
    public class GameRules : ScriptableObject
    {
        public event Action<int> CoinsUp;

        [Header("Default value")]
        [SerializeField] private int _coins;
        [SerializeField] private float _speed;
        [SerializeField] private Color _color;

        private int _coinsDefault;
        private float _speedDefault;
        private Color _colorDefault;

        public int Coins { get => _coinsDefault; set => CoinsUp?.Invoke(_coinsDefault = value); }
        public float Speed { get => _speedDefault; set => _speedDefault = value; }
        public Color Color { get => _colorDefault; set => _colorDefault = value; }

        private void OnEnable()
        {
            _coinsDefault = _coins;
            _speedDefault = _speed;
            _colorDefault = _color;
        }
    }
}