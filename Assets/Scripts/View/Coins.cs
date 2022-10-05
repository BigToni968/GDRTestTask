using UnityEngine;
using Game.Data;
using TMPro;

namespace Game.View
{
    public class Coins : MonoBehaviour
    {
        [SerializeField] private GameRules _rules;
        [SerializeField] private TextMeshProUGUI _coinText;

        private void OnEnable() => _rules.CoinsUp += CoinsUp;
        private void OnDisable() => _rules.CoinsUp -= CoinsUp;
        private void CoinsUp(int coins) => _coinText.SetText($"Coins: {coins}");
    }
}