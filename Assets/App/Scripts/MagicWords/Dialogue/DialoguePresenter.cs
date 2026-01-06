using System;
using System.Linq;
using System.Threading;
using App.Scripts.Tools;
using App.Tools;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.MagicWords
{
    public class DialoguePresenter : BaseDisposable
    {
        private readonly MagicWordsContent _content;
        private readonly EmojiConverter _emojiConverter;
        private DialogueView _view;
        private readonly CancellationTokenSource _lifeTimeToken = new();

        public DialoguePresenter(MagicWordsContent content, EmojiConverter emojiConverter)
        {
            _content = content;
            _emojiConverter = emojiConverter;
            LinkDisposable(new TokenDisposer(_lifeTimeToken));
        }

        public void BindView(DialogueView view)
        {
            _view = view;
        }

        public void StartDialogue()
        {
            StartDisplayDialogueAsync();
        }

        private async UniTaskVoid StartDisplayDialogueAsync()
        {
            foreach (var dialogue in _content.Dialogues)
            {            
                DisplayLine(dialogue);
                await UniTask.Delay(TimeSpan.FromSeconds(_content.DialogueDisplayInterval));
                
                if (_lifeTimeToken.IsCancellationRequested)
                    return;

            }
        }

        private void DisplayLine(DialogueData dialogue)
        {
            var convertedDialogue = new DialogueData
            {
                name = dialogue.name,
                text = _emojiConverter.ReplaceKeysWithEmojis(dialogue.text)
            };
                
            var avatarData = _content.Avatars.FirstOrDefault(x => x.Name == convertedDialogue.name);
            if (avatarData == null) 
                Debug.LogWarning($"Avatar data by name {dialogue.name} hasn't been found");
                
            _view.DisplayLine(convertedDialogue, avatarData);
        }
    }
}