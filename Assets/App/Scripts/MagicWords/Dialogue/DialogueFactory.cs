using UnityEngine;
using VContainer;

namespace App.MagicWords
{
    public class DialogueFactory
    {
        private readonly MagicWordsContent _magicWordsContent;
        private readonly Canvas _mainCanvas;
        private readonly IObjectResolver _objectResolver;

        public DialogueFactory(MagicWordsContent magicWordsContent, Canvas mainCanvas, IObjectResolver objectResolver)
        {
            _magicWordsContent = magicWordsContent;
            _mainCanvas = mainCanvas;
            _objectResolver = objectResolver;
        }

        public IDialogue Create()
        {
            var presenter = _objectResolver.Resolve<DialoguePresenter>();
            var view = CreateView();
            presenter.BindView(view);
            return new Dialogue(presenter, view);
        }

        private DialogueView CreateView()
        {
            return Object.Instantiate(_magicWordsContent.DialoguePrefab, _mainCanvas.transform);
        }
    }
}