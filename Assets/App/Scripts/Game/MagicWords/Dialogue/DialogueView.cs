using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace App.MagicWords
{
    public class DialogueView : MonoBehaviour
    {
        private AvatarsDataLoader _avatarsDataLoader;

        private readonly List<GameObject> _lines = new();
        private DialogueContent _dialogueContent;

        [Inject]
        public void Construct(DialogueContent dialogueContent)
        {
            _dialogueContent = dialogueContent;
        }
        
        public void DisplayLine(DialogueData dialogueData, AvatarData avatarData)
        {
            CreateLine(dialogueData, avatarData);
        }

        private void CreateLine(DialogueData dialogueData, AvatarData avatarData)
        {
            var prefab = GetLinePrefab(avatarData);
            var line = Instantiate(prefab, transform);
            line.SetName(dialogueData.name);
            line.SetText(dialogueData.text);

            if (avatarData != null) 
                line.SetAvatarSprite(avatarData.Sprite);
            
            _lines.Add(line.gameObject);

            if (_lines.Count > _dialogueContent.MaxLinesCount)
            {
                DestroyLastLine();
            }
        }

        private DialogueLine GetLinePrefab(AvatarData avatarData)
        {
            return avatarData == null || avatarData.Position == AvatarPosition.left ?
                _dialogueContent.DialogueLineLeft : 
                _dialogueContent.DialogueLineRight;
        }

        private void DestroyLastLine()
        {
            var lineToDestroy = _lines[0];
            _lines.Remove(lineToDestroy);
            Destroy(lineToDestroy);
        }
    }
}