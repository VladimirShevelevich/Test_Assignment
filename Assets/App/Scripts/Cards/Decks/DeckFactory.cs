using UnityEngine;
using VContainer;

namespace App.Cards.Deck
{
    public class DeckFactory
    {
        private readonly DecksContent _decksContent;
        private readonly IObjectResolver _objectResolver;

        public DeckFactory(DecksContent decksContent, IObjectResolver objectResolver)
        {
            _decksContent = decksContent;
            _objectResolver = objectResolver;
        }
        
        public DeckView CreateDeck(int deckIndex, int initialCardsAmount)
        {
            var deck = CreateDeck(deckIndex);
            _objectResolver.Inject(deck);
            CreateCards(initialCardsAmount, deck);
            return deck;
        }

        private DeckView CreateDeck(int deckIndex)
        {
            var position = _decksContent.DecksPositions[deckIndex];
            return Object.Instantiate(_decksContent.DeckPrefab, position, Quaternion.identity);
        }

        private void CreateCards(int initialCardAmount, DeckView deck)
        {
            for (var i = 0; i < initialCardAmount; i++)
            {
                var randomSprite = _decksContent.CardsSprites[Random.Range(0, _decksContent.CardsSprites.Length)];
                var card = CreateCard(randomSprite);
                deck.AddCard(card);
            }
        }

        private CardView CreateCard(Sprite sprite)
        {
            var view = Object.Instantiate(_decksContent.CardPrefab);
            view.SetSprite(sprite);
            return view;
        }
    }
}