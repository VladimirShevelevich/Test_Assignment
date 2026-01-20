using UnityEngine;

namespace App.AceOfShadows
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        /// <summary>
        /// Explicitly sets an order index to avoid the sorting order issue 
        /// </summary>
        public void SetOrderIndex(int index)
        {
            _spriteRenderer.sortingOrder = index;
        }
    }
}