using Game.Gameplay;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = ("Game/Data/" + nameof(Source)), fileName = nameof(Source))]
    public class Source : ScriptableObject
    {
        [SerializeField] private int _maxCoins;
        [SerializeField] private int _maxSpike;
        [Header("Prefabs")]
        [SerializeField] private Player _player;
        [SerializeField] private Coin _coin;
        [SerializeField] private Spike _spike;

        public int MaxCoins => _maxCoins;
        public int MaxSpike => _maxSpike;
        public Player Player => _player;
        public Coin Coin => _coin;
        public Spike Spike => _spike;
    }
}