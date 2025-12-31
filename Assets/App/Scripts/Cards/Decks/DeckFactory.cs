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
        
        public DeckView CreateDeck(int deckIndex, int initialCardsAmount)
        {
            var deck = CreateDeck(deckIndex);
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
                var position = deck.transform.position + Vector3.right * i * _decksContent.CardsGap;
                var randomSprite = _decksContent.CardsSprites[Random.Range(0, _decksContent.CardsSprites.Length)];
                CreateCard(randomSprite, deck.transform, position, i);
            }
        }

        private void CreateCard(Sprite sprite, Transform parent, Vector3 position, int index)
        {
            var view = Object.Instantiate(_decksContent.CardPrefab, position, Quaternion.identity, parent);
            view.SetSprite(sprite);
            view.SetOrderIndex(index);
        }
    }
}