using UnityEngine;

namespace App.Cards
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SerSortingOrder(int index)
        {
            _spriteRenderer.sortingOrder = index;
        }
    }
}