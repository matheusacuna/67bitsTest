using UnityEngine;
using TMPro;
using Player;

namespace Managers
{
    public class ShopManager : MonoBehaviour
    {
        [Header("Values Shop")]
        public float moneyAmount;
        public float moneyAmountForLevel;
        public float moneyAmountForNewColor;
        public TextMeshProUGUI moneyAmountText;
        public TextMeshProUGUI moneyAmountShopText;

        [Header("References")]
        [SerializeField] private Stacking stackingManager;
        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
        [SerializeField] private Material[] materialReference;

        private void Update()
        {
            moneyAmountText.text = $"${moneyAmount}";
            moneyAmountShopText.text = $"${moneyAmount}";
        }

        public void BuyLevel()
        {
            if (moneyAmount >= moneyAmountForLevel)
            {
                DecrementMoney(moneyAmountForLevel);
                stackingManager.stackingLimit++;
            }
        }

        public void BuyNewColor()
        {
            if (moneyAmount >= moneyAmountForNewColor)
            {
                DecrementMoney(moneyAmountForNewColor);
                skinnedMeshRenderer.material = materialReference[Random.Range(0, materialReference.Length)];
            }
        }

        public void IncrementMoney(float value)
        {
            moneyAmount += value;
        }

        public void DecrementMoney(float value)
        {
            moneyAmount -= value;
        }
    }
}

