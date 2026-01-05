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
        private DialogueView _view;
        private readonly CancellationTokenSource _lifeTimeToken = new();

        public DialoguePresenter(MagicWordsContent content)
        {
            _content = content;
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
                var avatarData = _content.Avatars.FirstOrDefault(x => x.Name == dialogue.name);
                if (avatarData == null) 
                    Debug.LogWarning($"Avatar data by name {dialogue.name} hasn't been found");
                
                _view.DisplayLine(dialogue, avatarData);
                
                await UniTask.Delay(TimeSpan.FromSeconds(_content.DialogueDisplayInterval));
                
                if (_lifeTimeToken.IsCancellationRequested)
                    return;

            }
        }
    }
}