using System.Collections.Generic;
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

        private List<GameObject> _lines = new();

        [Inject]
        public void Construct(MagicWordsContent magicWordsContent)
        {
            _content = magicWordsContent;
        }
        
        public void DisplayLine(DialogueData dialogueData, AvatarData avatarData)
        {
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
            
            _lines.Add(line.gameObject);

            if (_lines.Count > _content.MaxLinesCount)
            {
                DestroyLastLine();
            }
        }

        private void DestroyLastLine()
        {
            var lineToDestroy = _lines[0];
            _lines.Remove(lineToDestroy);
            Destroy(lineToDestroy);
        }
    }
}