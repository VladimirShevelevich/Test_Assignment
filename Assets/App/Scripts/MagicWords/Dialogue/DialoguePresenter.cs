using System.Threading;
using App.Tools;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.MagicWords
{
    public class DialoguePresenter : BaseDisposable
    {
        private readonly AvatarsDataLoader _avatarsDataLoader;
        private readonly DialogueDataLoader _dialogueDataLoader;
        private readonly Canvas _mainCanvas;

        private readonly CancellationTokenSource _lifeTimeCts = new();
        private DialogueView _view;

        public DialoguePresenter(AvatarsDataLoader avatarsDataLoader, DialogueDataLoader dialogueDataLoader, Canvas mainCanvas)
        {
            _avatarsDataLoader = avatarsDataLoader;
            _dialogueDataLoader = dialogueDataLoader;
            _mainCanvas = mainCanvas;
        }

        public void BindView(DialogueView view)
        {
            _view = view;
        }

        public void StartDialogue()
        {
            StartDisplayDialogueAsync();
        }

        private void StartDisplayDialogueAsync()
        {
            foreach (var dialogue in _dialogueDataLoader.Dialogues)
            {
                _view.DisplayLine(dialogue);
            }
        }
    }
}