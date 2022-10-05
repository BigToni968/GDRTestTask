using UnityEngine;
using Game.Data;

namespace Game.Gameplay
{
    public class Restart : MonoBehaviour
    {
        [SerializeField] private GameRules _rules;

        public void CoinReset() => _rules.Coins = 0;
    }
}