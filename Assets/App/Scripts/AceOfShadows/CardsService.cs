using System;
using System.Collections.Generic;
using App.Tools;
using UniRx;
using VContainer.Unity;

namespace App.AceOfShadows
{
    public class CardsService : BaseDisposable, IInitializable
    {
        public IObservable<Unit> OnMovingComplete => _cardsMover.OnMovingComplete;
        
        private readonly DeckFactory _deckFactory;
        private readonly MovementContent _movementContent;
        private readonly DecksContent _decksContent;
        private CardsMover _cardsMover;

        private List<DeckView> Decks { get; } = new();
        
        public CardsService(DeckFactory deckFactory, MovementContent movementContent, DecksContent decksContent)
        {
            _deckFactory = deckFactory;
            _movementContent = movementContent;
            _decksContent = decksContent;
        }
        
        public void Initialize()
        {
            CreateDecks();
            CreateMover();
        }

        private void CreateMover()
        {
            _cardsMover = new CardsMover(Decks, _movementContent, _decksContent.TotalCardsAmount);
            LinkDisposable(_cardsMover);
        }

        private void CreateDecks()
        {
            Decks.Add(_deckFactory.CreateDeck(0, _decksContent.TotalCardsAmount));
            Decks.Add(_deckFactory.CreateDeck(1, 0));
            foreach (var deck in Decks) 
                LinkDisposable(new GameObjectDisposer(deck.gameObject));
        }
    }
}