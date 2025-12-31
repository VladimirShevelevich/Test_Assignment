using System;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace App.Cards.Deck
{
    public class DeckView : MonoBehaviour
    {
        public IObservable<int> OnMovementComplete => _onMovementComplete;
        private readonly ReactiveCommand<int> _onMovementComplete = new();
        
        public Vector3 Position => 
            transform.position;

        public int CardsCurrentAmount =>
            transform.childCount;

        public void MoveLastCardTo(Transform parent, Vector3 position, float duration, int orderIndex)
        {
            if (transform.childCount == 0)
            {
                Debug.LogError("Cards deck is empty");
                return;
            }

            var card = transform.GetChild(transform.childCount - 1);
            card.transform.SetParent(parent);
            card.GetComponent<CardView>().SetOrderIndex(orderIndex);
            card.DOMove(position, duration).SetLink(gameObject).OnComplete(() =>
            {
                _onMovementComplete.Execute(orderIndex);
            });
        }

        public void Dispose()
        {
            if (gameObject != null)
                Destroy(gameObject);
        }
    }
}