using System.Collections.Generic;
using App.Cards.Deck;
using App.Tools;
using Arkanoid.Tools.Disposable;
using VContainer.Unity;

namespace App.Cards
{
    public class DecksService : BaseDisposable, IInitializable
    {
        private readonly DeckFactory _deckFactory;
        private readonly DecksContent _decksContent;

        public List<DeckView> Decks { get; private set; } = new();
        
        public DecksService(DeckFactory deckFactory, DecksContent decksContent)
        {
            _deckFactory = deckFactory;
            _decksContent = decksContent;
        }
        
        public void Initialize()
        {
            CreateDecks();
        }

        private void CreateDecks()
        {
            Decks.Add(_deckFactory.CreateDeck(0, _decksContent.InitialCardsAmount));
            Decks.Add(_deckFactory.CreateDeck(1, 0));
            foreach (var deck in Decks) 
                AddDisposable(new GameObjectDisposer(deck.gameObject));
        }
    }
}