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

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void SetAvatarSprite(Sprite sprite)
        {
            if (sprite != null)
                _avatarImage.sprite = sprite;
        }
        
        public void SetName(string name)
        {
            _name.text = name;
        }
    }
}