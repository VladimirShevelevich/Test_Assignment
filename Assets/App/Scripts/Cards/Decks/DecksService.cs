using App.Cards.Deck;
using App.Tools;
using VContainer.Unity;

namespace App.Cards
{
    public class DecksService : BaseDisposable, IInitializable
    {
        private readonly DeckFactory _deckFactory;
        private readonly DecksContent _decksContent;

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
            var firstDeck = _deckFactory.CreateDeck(0);
            var secondDeck = _deckFactory.CreateDeck(1);
            AddDisposable(firstDeck);
            AddDisposable(secondDeck);

            firstDeck.SpawnCards(_decksContent.CardsPrefabs);
        }
    }
}