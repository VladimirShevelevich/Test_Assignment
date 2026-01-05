using System.Threading;
using App.Tools;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.MagicWords
{
    public class DialoguePresenter : BaseDisposable
    {
        private readonly MagicWordsContent _content;

        private DialogueView _view;

        public DialoguePresenter(MagicWordsContent content)
        {
            _content = content;
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
            foreach (var dialogue in _content.Dialogues)
            {
                _view.DisplayLine(dialogue);
            }
        }
    }
}