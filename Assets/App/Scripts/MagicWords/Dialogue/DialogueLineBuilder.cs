using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.MagicWords
{
    public class DialogueLine : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _avatarImage;

        public DialogueLine SetPosition(AvatarPosition position)
        {
            _text.alignment = position == AvatarPosition.right
                ? TextAlignmentOptions.Right
                : TextAlignmentOptions.Left;

            return this;
        }

        public DialogueLine SetText(string text)
        {
            _text.text = text;
            return this;
        }

        public DialogueLine SetAvatarSprite(Sprite sprite)
        {
            _avatarImage.sprite = sprite;
            return this;
        }

        public DialogueLine SetName(string name)
        {
            _name.text = name;
            return this;
        }
    }
}