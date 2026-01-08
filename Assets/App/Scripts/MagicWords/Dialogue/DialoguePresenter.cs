using System;
using System.Linq;
using System.Threading;
using App.Tools;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.MagicWords
{
    
    /// <summary>
    /// Controls the dialogue sequence
    /// </summary>
    public class DialoguePresenter : BaseDisposable
    {
        private readonly DialogueContent _dialogueContent;
        private DialogueView _view;
        private readonly CancellationTokenSource _lifeTimeToken = new();

        public DialoguePresenter(DialogueContent dialogueContent)
        {
            _dialogueContent = dialogueContent;
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
            foreach (var dialogue in _dialogueContent.Dialogues)
            {            
                DisplayLine(dialogue);
                await UniTask.Delay(TimeSpan.FromSeconds(_dialogueContent.DialogueDisplayInterval));
                
                if (_lifeTimeToken.IsCancellationRequested)
                    return;
            }
        }

        private void DisplayLine(DialogueData dialogue)
        {
            var convertedDialogue = new DialogueData
            {
                name = dialogue.name,
                text = EmojiConverter.ReplaceKeysWithEmojis(dialogue.text)
            };
                
            var avatarData = _dialogueContent.Avatars.FirstOrDefault(x => x.Name == convertedDialogue.name);
            if (avatarData == null) 
                Debug.LogWarning($"Avatar data by name {dialogue.name} hasn't been found");
                
            _view.DisplayLine(convertedDialogue, avatarData);
        }
    }
}