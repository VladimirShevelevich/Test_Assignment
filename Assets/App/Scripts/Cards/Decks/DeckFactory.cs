using UnityEngine;

namespace App.Cards.Deck
{
    public class DeckFactory
    {
        private readonly DecksContent _decksContent;

        public DeckFactory(DecksContent decksContent)
        {
            _decksContent = decksContent;
        }
        
        public IDeck CreateDeck(int deckIndex)
        {
            var view = CreateView(deckIndex);
            return view;
        }

        private DeckView CreateView(int deckIndex)
        {
            var position = _decksContent.DecksPositions[deckIndex];
            return Object.Instantiate(_decksContent.DeckPrefab, position, Quaternion.identity);
        }
    }
}