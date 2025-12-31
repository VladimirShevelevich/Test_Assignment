using UnityEngine;

namespace App.Cards.Deck
{
    public class DeckView : MonoBehaviour, IDeck
    {
        public void SpawnCards(CardView[] prefabs)
        {
            foreach (var cardView in prefabs)
            {
                Instantiate(cardView, transform);
            }
        }

        public void Dispose()
        {
            if (gameObject != null)
                Destroy(gameObject);
        }
    }
}