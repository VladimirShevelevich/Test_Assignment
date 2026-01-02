using System;
using System.Threading;
using App.Scripts.Tools;
using App.Tools;
using Cysharp.Threading.Tasks;
using UniRx;
using VContainer.Unity;

namespace App.Cards
{
    public class CardsMover : BaseDisposable, IInitializable
    {
        public IObservable<Unit> OnMovingComplete => _onMovingComplete;
        private readonly ReactiveCommand _onMovingComplete = new();
        
        private readonly CardsService _cardsService;
        private readonly CardsContent _cardsContent;
        
        private DeckView _firstDeck;
        private DeckView _secondDeck;

        public CardsMover(CardsService cardsService, CardsContent cardsContent)
        {
            _cardsService = cardsService;
            _cardsContent = cardsContent;
        }
        
        public void Initialize()
        {
            _firstDeck = _cardsService.Decks[0];
            _secondDeck = _cardsService.Decks[1];
            
            AddDisposable(_secondDeck.CardsAmount.Subscribe(OnSecondDeckAmountChanged));
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
            AddDisposable(new TokenDisposer(tokenSource));
            
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