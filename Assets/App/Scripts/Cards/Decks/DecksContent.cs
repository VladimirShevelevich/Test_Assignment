using App.Cards.Deck;
using UnityEngine;

namespace App.Cards
{
    [CreateAssetMenu(fileName = "DecksContent", menuName = "Content/Decks")]
    public class DecksContent : ScriptableObject
    {
        [field: SerializeField] public DeckView DeckPrefab { get; private set; }
        [field: SerializeField] public Vector3[] DecksPositions { get; private set; }
    }
}