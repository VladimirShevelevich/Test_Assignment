using System.Linq;
using App.Scripts.MagicWords;
using UnityEngine;
using VContainer;

namespace App.MagicWords
{
    public class DialogueView : MonoBehaviour
    {
        private MagicWordsContent _content;
        private AvatarsDataLoader _avatarsDataLoader;

        [Inject]
        public void Construct(MagicWordsContent magicWordsContent)
        {
            _content = magicWordsContent;
        }
        
        public void DisplayLine(DialogueData dialogueData)
        {
            return;
            var avatarData = _content.Avatars.FirstOrDefault(x => x.Name == dialogueData.name);
            if (avatarData == null)
            {
                Debug.LogError("Avatar data is not found");
                return;
            }
            
            BuildLine(dialogueData, avatarData);
        }

        private void BuildLine(DialogueData dialogueData, AvatarData avatarData)
        {
            var line = Instantiate(_content.DialogueLinePrefab, transform).
                SetText(dialogueData.text).
                SetName(dialogueData.name).
                SetAvatarSprite(avatarData.Sprite).
                SetPosition(avatarData.Position);
        }
    }
}