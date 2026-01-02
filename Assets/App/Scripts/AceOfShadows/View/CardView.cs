using UnityEngine;

namespace App.AceOfShadows.View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        public void SetOrderIndex(int index)
        {
            _spriteRenderer.sortingOrder = index;
        }
    }
}