using App.Cards.Deck;
using VContainer.Unity;

namespace App.Cards
{
    public class DecksService : IInitializable
    {
        private readonly DeckFactory _deckFactory;

        public DecksService(DeckFactory deckFactory)
        {
            _deckFactory = deckFactory;
        }
        
        public void Initialize()
        {
            CreateDecks();
        }

        private void CreateDecks()
        {
            var firstDeck = _deckFactory.CreateDeck(0);
            var secondDeck = _deckFactory.CreateDeck(1);
        }
    }
}