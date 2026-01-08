using System;
using System.Collections.Generic;
using System.Threading;
using App.Tools;
using Cysharp.Threading.Tasks;
using UniRx;

namespace App.AceOfShadows
{
    public class CardsMover : BaseDisposable
    {
        /// <summary>
        /// All cards have been moved
        /// </summary>
        public IObservable<Unit> OnMovingComplete => _onMovingComplete;
        private readonly ReactiveCommand _onMovingComplete = new();
        
        private readonly MovementContent _movementContent;
        private readonly int _totalCardsAmount;

        private readonly DeckView _firstDeck;
        private readonly DeckView _secondDeck;

        public CardsMover(IReadOnlyList<DeckView> decks, MovementContent movementContent, int totalCardsAmount)
        {
            _movementContent = movementContent;
            _totalCardsAmount = totalCardsAmount;
            _firstDeck = decks[0];
            _secondDeck = decks[1];
            
            SubscribeOnSecondDeckAmountChange();
            StartMovingRoutineAsync();
        }

        private void SubscribeOnSecondDeckAmountChange()
        {
            LinkDisposable(_secondDeck.CardsAmount.Subscribe(OnSecondDeckAmountChanged));
        }

        private void OnSecondDeckAmountChanged(int currentAmount)
        {
            if (currentAmount >= _totalCardsAmount)
                _onMovingComplete?.Execute();
        }

        private async UniTaskVoid StartMovingRoutineAsync()
        {
            //using cancellationToken to handle the task disposing
            var tokenSource = new CancellationTokenSource();
            LinkDisposable(new TokenDisposer(tokenSource));
            
            while (_firstDeck.CardsAmount.Value > 0)
            {
                MoveCard();
                await UniTask.Delay(TimeSpan.FromSeconds(_movementContent.MoveTimeInterval));
                
                if (tokenSource.IsCancellationRequested)
                    return;
            }
        }

        private void MoveCard()
        {
            var cardToMove = _firstDeck.PopCard();
            _secondDeck.PullCard(cardToMove, _movementContent.MoveDuration);
        }
    }
}