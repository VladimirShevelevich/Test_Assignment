using System;
using System.Threading;
using App.Cards;
using App.Cards.Deck;
using App.Scripts.Tools;
using App.Tools;
using Cysharp.Threading.Tasks;
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
            
            StartMovingRoutineAsync();
        }

        private async UniTaskVoid StartMovingRoutineAsync()
        {
            //using cancellationToken to handle the task disposing
            var tokenSource = new CancellationTokenSource();
            AddDisposable(new TokenDisposer(tokenSource));
            
            var index = 0;
            while (_firstDeck.CardsCurrentAmount > 0)
            {
                var position = _secondDeck.Position + Vector3.right * _decksContent.CardsGap * index;
                _firstDeck.MoveLastCardTo(_secondDeck.transform, position, _decksContent.MoveDuration, index);
                index++;
                await UniTask.Delay(TimeSpan.FromSeconds(_decksContent.MoveTimeInterval));
                
                if (tokenSource.IsCancellationRequested)
                    return;
            }
        }
    }
}