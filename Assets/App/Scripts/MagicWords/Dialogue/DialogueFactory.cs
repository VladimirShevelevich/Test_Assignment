using UnityEngine;
using VContainer;

namespace App.MagicWords
{
    public class DialogueFactory
    {
        private readonly DialogueContent _dialogueContent;
        private readonly Canvas _mainCanvas;
        private readonly IObjectResolver _objectResolver;

        public DialogueFactory(DialogueContent dialogueContent, Canvas mainCanvas, IObjectResolver objectResolver)
        {
            _dialogueContent = dialogueContent;
            _mainCanvas = mainCanvas;
            _objectResolver = objectResolver;
        }

        public IDialogue Create()
        {
            var presenter = _objectResolver.Resolve<DialoguePresenter>();
            var view = CreateView();
            _objectResolver.Inject(view);
            presenter.BindView(view);
            return new Dialogue(presenter, view);
        }

        private DialogueView CreateView()
        {
            return Object.Instantiate(_dialogueContent.DialoguePrefab, _mainCanvas.transform);
        }
    }
}