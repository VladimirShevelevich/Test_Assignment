using System;

namespace App.Cards.Deck
{
    public interface IDeck : IDisposable
    {
        void SpawnCards(CardView[] prefabs);
    }
}