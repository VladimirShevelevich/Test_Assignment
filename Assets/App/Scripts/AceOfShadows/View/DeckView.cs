using DG.Tweening;
using UniRx;
using UnityEngine;
using VContainer;

namespace App.AceOfShadows
{
    public class DeckView : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<int> CardsAmount => _cardsAmount;
        private readonly ReactiveProperty<int> _cardsAmount = new();
        
        private DecksContent _decksContent;
        
        /// <summary>
        /// An index used to handle attached cards sorting
        /// </summary>
        private int _deckOrderIndex;

        [Inject]
        public void Construct(DecksContent decksContent)
        {
            _decksContent = decksContent;
        }

        public void SetDeckOrderIndex(int orderIndex) =>
            _deckOrderIndex = orderIndex;

        /// <summary>
        /// Attach to the transform and set the initial position
        /// </summary>
        public void AddCard(CardView cardView)
        {
            cardView.transform.SetParent(transform);
            cardView.transform.position = GetNewCardPosition();
            cardView.SetOrderIndex(_deckOrderIndex + _cardsAmount.Value);
            _cardsAmount.Value++;
        }

        /// <summary>
        /// Deattach the transfrom and return
        /// </summary>
        public CardView PopCard()
        {
            var cardTransform = transform.GetChild(transform.childCount - 1);
            cardTransform.parent = null;
            _cardsAmount.Value--;
            return cardTransform.GetComponent<CardView>();
        }
        
        /// <summary>
        /// Attach the transform and move to the position
        /// </summary>
        public void PullCard(CardView cardView, float moveDuration)
        {
            cardView.transform.SetParent(transform);
            cardView.SetOrderIndex(_deckOrderIndex + _cardsAmount.Value);
            var position = GetNewCardPosition();
            cardView.transform.DOMove(position, moveDuration).SetLink(gameObject).OnComplete(() =>
                OnCardPullComplete(cardView));
        }

        private void OnCardPullComplete(CardView cardView)
        {
            _cardsAmount.Value++;
        }

        private Vector3 GetNewCardPosition()
        {
            return transform.position + Vector3.down * _cardsAmount.Value * _decksContent.CardsGap;
        }
    }
}