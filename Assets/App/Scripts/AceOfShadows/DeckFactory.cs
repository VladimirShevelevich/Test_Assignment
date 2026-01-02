using App.AceOfShadows.View;
using UnityEngine;
using VContainer;

namespace App.AceOfShadows
{
    public class DeckFactory
    {
        private readonly CardsContent _cardsContent;
        private readonly IObjectResolver _objectResolver;

        public DeckFactory(CardsContent cardsContent, IObjectResolver objectResolver)
        {
            _cardsContent = cardsContent;
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
            var position = _cardsContent.DecksPositions[deckIndex];
            var deck = Object.Instantiate(_cardsContent.DeckPrefab, position, Quaternion.identity);
            deck.SetDeckOrderIndex(deckIndex * _cardsContent.InitialCardsAmount);
            return deck;
        }

        private void CreateCards(int initialCardAmount, DeckView deck)
        {
            for (var i = 0; i < initialCardAmount; i++)
            {
                var randomSprite = _cardsContent.CardsSprites[Random.Range(0, _cardsContent.CardsSprites.Length)];
                var card = CreateCard(randomSprite);
                deck.AddCard(card);
            }
        }

        private CardView CreateCard(Sprite sprite)
        {
            var view = Object.Instantiate(_cardsContent.CardPrefab);
            view.SetSprite(sprite);
            return view;
        }
    }
}