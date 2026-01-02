using System.Collections.Generic;
using App.AceOfShadows.View;
using App.Tools;
using VContainer.Unity;

namespace App.AceOfShadows
{
    public class CardsService : BaseDisposable, IInitializable
    {
        private readonly DeckFactory _deckFactory;
        private readonly CardsContent _cardsContent;

        public List<DeckView> Decks { get; } = new();
        
        public CardsService(DeckFactory deckFactory, CardsContent cardsContent)
        {
            _deckFactory = deckFactory;
            _cardsContent = cardsContent;
        }
        
        public void Initialize()
        {
            CreateDecks();
        }

        private void CreateDecks()
        {
            Decks.Add(_deckFactory.CreateDeck(0, _cardsContent.InitialCardsAmount));
            Decks.Add(_deckFactory.CreateDeck(1, 0));
            foreach (var deck in Decks) 
                AddDisposable(new GameObjectDisposer(deck.gameObject));
        }
    }
}