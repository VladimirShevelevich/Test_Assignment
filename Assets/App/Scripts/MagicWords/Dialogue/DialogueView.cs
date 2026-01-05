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
            var avatarData = _content.Avatars.FirstOrDefault(x => x.Name == dialogueData.name);
            if (avatarData == null)
            {
                Debug.LogWarning($"Avatar data by name {dialogueData.name} hasn't been found");
                return;
            }
            
            CreateLine(dialogueData, avatarData);
        }

        private void CreateLine(DialogueData dialogueData, AvatarData avatarData)
        {
            var prefab = avatarData == null || avatarData.Position == AvatarPosition.left ?
                _content.DialogueLineLeft : 
                _content.DialogueLineRight;
            var line = Instantiate(prefab, transform);
            line.SetText($"{dialogueData.name}: {dialogueData.text}");

            if (avatarData != null)
            {
                line.SetAvatarSprite(avatarData.Sprite);
                line.SetPosition(avatarData.Position);
            }
        }
    }
}