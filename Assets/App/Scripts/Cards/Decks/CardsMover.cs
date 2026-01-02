using System;
using System.Threading;
using App.Cards;
using App.Cards.Deck;
using App.Scripts.Tools;
using App.Tools;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace App.Scripts.Cards.Decks
{
    public class CardsMover : BaseDisposable, IInitializable
    {
        private readonly DecksService _decksService;
        private readonly DecksContent _decksContent;
        
        private DeckView _firstDeck;
        private DeckView _secondDeck;

        public CardsMover(DecksService decksService, DecksContent decksContent)
        {
            _decksService = decksService;
            _decksContent = decksContent;
        }
        
        public void Initialize()
        {
            _firstDeck = _decksService.Decks[0];
            _secondDeck = _decksService.Decks[1];
            
            AddDisposable(_secondDeck.CardsAmount.Subscribe(OnSecondDeckAmountChanged));
            StartMovingRoutineAsync();
        }
        
        private void OnSecondDeckAmountChanged(int amount)
        {
            if (amount >= _decksContent.InitialCardsAmount) 
                OnMovingComplete();
        }

        private void OnMovingComplete()
        {
            Debug.Log("Movement is completed");
        }

        private async UniTaskVoid StartMovingRoutineAsync()
        {
            //using cancellationToken to handle the task disposing
            var tokenSource = new CancellationTokenSource();
            AddDisposable(new TokenDisposer(tokenSource));
            
            while (_firstDeck.CardsAmount.Value > 0)
            {
                var cardToMove = _firstDeck.PopCard();
                _secondDeck.PullCard(cardToMove);
                await UniTask.Delay(TimeSpan.FromSeconds(_decksContent.MoveTimeInterval));
                
                if (tokenSource.IsCancellationRequested)
                    return;
            }
        }
    }
}