using App.AceOfShadows.View;
using UnityEngine;

namespace App.AceOfShadows
{
    [CreateAssetMenu(fileName = "DecksContent", menuName = "Content/Decks")]
    public class CardsContent : ScriptableObject
    {
        [field: SerializeField] public DeckView DeckPrefab { get; private set; }
        [field: SerializeField] public CardView CardPrefab { get; private set; }
        [field: SerializeField] public Vector3[] DecksPositions { get; private set; }
        [field: SerializeField] public Sprite[] CardsSprites { get; private set; }
        [field: SerializeField] public float CardsGap { get; private set; }
        [field: SerializeField] public float MoveDuration { get; private set; }
        [field: SerializeField] public float MoveTimeInterval { get; private set; }
        [field: SerializeField] public int InitialCardsAmount { get; private set; }
        [field: SerializeField] public GameObject MessagePrefab { get; private set; }
    }
}