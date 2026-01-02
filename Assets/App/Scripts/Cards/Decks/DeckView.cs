using DG.Tweening;
using UniRx;
using UnityEngine;
using VContainer;

namespace App.Cards.Deck
{
    public class DeckView : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<int> CardsAmount => _cardsAmount;
        private readonly ReactiveProperty<int> _cardsAmount = new();
        
        private DecksContent _decksContent;

        [Inject]
        public void Construct(DecksContent decksContent)
        {
            _decksContent = decksContent;
        }

        public void AddCard(CardView cardView)
        {
            cardView.transform.SetParent(transform);
            cardView.transform.position = GetNewCardPosition();
            cardView.SetOrderIndex(_cardsAmount.Value);
            _cardsAmount.Value++;
        }

        public CardView PopCard()
        {
            var cardTransform = transform.GetChild(transform.childCount - 1);
            cardTransform.parent = null;
            _cardsAmount.Value--;
            return cardTransform.GetComponent<CardView>();
        }
        
        public void PullCard(CardView cardView)
        {
            cardView.transform.SetParent(transform);
            var position = GetNewCardPosition();
            cardView.transform.DOMove(position, _decksContent.MoveDuration).SetLink(gameObject).OnComplete(() =>
                OnCardPullComplete(cardView));
        }

        private void OnCardPullComplete(CardView cardView)
        {
            cardView.SetOrderIndex(_cardsAmount.Value);
            _cardsAmount.Value++;
        }

        private Vector3 GetNewCardPosition()
        {
            return transform.position + Vector3.right * _cardsAmount.Value * _decksContent.CardsGap;
        }
    }
}