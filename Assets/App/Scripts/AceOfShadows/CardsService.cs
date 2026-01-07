using System;
using System.Collections.Generic;
using App.AceOfShadows.View;
using App.Tools;
using UniRx;
using VContainer.Unity;

namespace App.AceOfShadows
{
    public class CardsService : BaseDisposable, IInitializable
    {
        public IObservable<Unit> OnMovingComplete => _cardsMover.OnMovingComplete;
        
        private readonly DeckFactory _deckFactory;
        private readonly CardsContent _cardsContent;
        private CardsMover _cardsMover;

        private List<DeckView> Decks { get; } = new();
        
        public CardsService(DeckFactory deckFactory, CardsContent cardsContent)
        {
            _deckFactory = deckFactory;
            _cardsContent = cardsContent;
        }
        
        public void Initialize()
        {
            CreateDecks();
            CreateMover();
        }

        private void CreateMover()
        {
            _cardsMover = new CardsMover(Decks, _cardsContent);
            LinkDisposable(_cardsMover);
        }

        private void CreateDecks()
        {
            Decks.Add(_deckFactory.CreateDeck(0, _cardsContent.InitialCardsAmount));
            Decks.Add(_deckFactory.CreateDeck(1, 0));
            foreach (var deck in Decks) 
                LinkDisposable(new GameObjectDisposer(deck.gameObject));
        }
    }
}