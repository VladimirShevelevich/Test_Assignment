using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.MagicWords
{
    public class DialogueLine : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _avatarImage;

        public void SetPosition(AvatarPosition position)
        {
            _text.alignment = position == AvatarPosition.right
                ? TextAlignmentOptions.Right
                : TextAlignmentOptions.Left;
        }

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void SetAvatarSprite(Sprite sprite)
        {
            if (sprite != null)
                _avatarImage.sprite = sprite;
        }
    }
}