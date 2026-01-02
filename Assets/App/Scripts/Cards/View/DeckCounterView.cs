using TMPro;
using UniRx;
using UnityEngine;

namespace App.Cards
{
    public class DeckCounterView : MonoBehaviour
    {
        [SerializeField] private DeckView _deckView;
        [SerializeField] private TMP_Text _counterText;

        private void Start()
        {
            _deckView.CardsAmount.Subscribe(OnCardAmountChanged).
                AddTo(gameObject);
        }

        private void OnCardAmountChanged(int amount)
        {
            UpdateCounter(amount);
        }

        private void UpdateCounter(int amount)
        {
            _counterText.text = amount.ToString();
        }
    }
}