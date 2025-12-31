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
        
        public IDeck CreateDeck(int deckIndex, CardView[] initialCardsPrefabs = null)
        {
            var deck = CreateDeck(deckIndex);

            if (initialCardsPrefabs != null)
            {
                CreateCards(initialCardsPrefabs, deck);
            }

            return deck;
        }

        private DeckView CreateDeck(int deckIndex)
        {
            var position = _decksContent.DecksPositions[deckIndex];
            return Object.Instantiate(_decksContent.DeckPrefab, position, Quaternion.identity);
        }

        private void CreateCards(CardView[] initialCardsPrefabs, DeckView deck)
        {
            for (var i = 0; i < initialCardsPrefabs.Length; i++)
            {
                var position = deck.transform.position + Vector3.right * i * _decksContent.CardsGap;
                var cardPrefab = initialCardsPrefabs[i];
                CreateCard(cardPrefab, deck.transform, position, i);
            }
        }

        private void CreateCard(CardView prefab, Transform parent, Vector3 position, int index)
        {
            var view = Object.Instantiate(prefab, position, Quaternion.identity, parent);
            view.SerSortingOrder(index);
        }
    }
}