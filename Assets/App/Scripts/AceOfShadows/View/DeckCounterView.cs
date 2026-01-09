using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

namespace App.AceOfShadows
{
    public class DeckCounterView : MonoBehaviour
    {
        [SerializeField] private DeckView _deckView;
        [SerializeField] private TMP_Text _counterText;
        private ICardsService _cardsService;

        [Inject]
        public void Construct(ICardsService cardsService)
        {
            _cardsService = cardsService;
        }
        
        private void Start()
        {
            _deckView.CardsAmount.Subscribe(OnCardAmountChanged).
                AddTo(gameObject);
            _cardsService.OnMovingComplete.Subscribe(_ => OnMovingComplete()).
                AddTo(gameObject);
        }

        private void OnMovingComplete()
        {
            HideCounter();
        }

        private void OnCardAmountChanged(int amount)
        {
            UpdateCounter(amount);
        }

        private void UpdateCounter(int amount)
        {
            _counterText.text = amount > 0 ? amount.ToString() : "";
            PlayValueChangeAnimation();
        }

        private void PlayValueChangeAnimation()
        {
            _counterText.transform.localScale = Vector3.zero;
            _counterText.transform.DOScale(1, 0.25f).SetEase(Ease.Linear).
                SetLink(gameObject);
        }

        private void HideCounter()
        {
            _counterText.gameObject.SetActive(false);
        }
    }
}