using UnityEngine;
using TMPro;


namespace Managers
{
    public class ShopManager : MonoBehaviour
    {
        [Header("Values Shop")]
        public float moneyAmount;
        public float moneyAmountForLevel;
        public float moneyAmountForNewColor;
        public TextMeshProUGUI moneyAmountText;

        [Header("Feedback Money")]
        public GameObject feedbackMoney;

        [Header("References")]
        [SerializeField] private StackingManager stackingManager;
        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
        [SerializeField] private Material[] materialReference;

        private void Update()
        {
            moneyAmountText.text = $"${moneyAmount}";
        }

        public void BuyLevel()
        {
            if (moneyAmount >= moneyAmountForLevel)
            {
                DecrementMoney(moneyAmountForLevel);
                stackingManager.maxStackLimit++;
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

