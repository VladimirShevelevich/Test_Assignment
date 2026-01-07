using System;
using System.Collections.Generic;
using System.Threading;
using App.AceOfShadows.View;
using App.Scripts.Tools;
using App.Tools;
using Cysharp.Threading.Tasks;
using UniRx;

namespace App.AceOfShadows
{
    public class CardsMover : BaseDisposable
    {
        public IObservable<Unit> OnMovingComplete => _onMovingComplete;
        private readonly ReactiveCommand _onMovingComplete = new();
        
        private readonly CardsContent _cardsContent;
        
        private readonly DeckView _firstDeck;
        private readonly DeckView _secondDeck;

        public CardsMover(IReadOnlyList<DeckView> decks, CardsContent cardsContent)
        {
            _cardsContent = cardsContent;
            _firstDeck = decks[0];
            _secondDeck = decks[1];
            
            LinkDisposable(_secondDeck.CardsAmount.Subscribe(OnSecondDeckAmountChanged));
            StartMovingRoutineAsync();
        }
        
        private void OnSecondDeckAmountChanged(int amount)
        {
            if (amount >= _cardsContent.InitialCardsAmount)
                _onMovingComplete?.Execute();
        }

        private async UniTaskVoid StartMovingRoutineAsync()
        {
            //using cancellationToken to handle the task disposing
            var tokenSource = new CancellationTokenSource();
            LinkDisposable(new TokenDisposer(tokenSource));
            
            while (_firstDeck.CardsAmount.Value > 0)
            {
                var cardToMove = _firstDeck.PopCard();
                _secondDeck.PullCard(cardToMove);
                await UniTask.Delay(TimeSpan.FromSeconds(_cardsContent.MoveTimeInterval));
                
                if (tokenSource.IsCancellationRequested)
                    return;
            }
        }
    }
}