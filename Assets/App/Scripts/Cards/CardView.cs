using UnityEngine;

namespace App.Cards
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetSprite(Sprite sprite, int orderIndex)
        {
            _spriteRenderer.sprite = sprite;
            _spriteRenderer.sortingOrder = orderIndex;
        }
    }
}