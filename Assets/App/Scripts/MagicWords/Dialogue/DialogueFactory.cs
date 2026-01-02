using UnityEngine;

namespace App.MagicWords
{
    public class DialogueFactory
    {
        private readonly MagicWordsContent _content;
        private readonly Canvas _mainCanvas;

        public DialogueFactory(MagicWordsContent content, Canvas mainCanvas)
        {
            _content = content;
            _mainCanvas = mainCanvas;
        }

        public DialogueView CreateDialogueView()
        {
            return Object.Instantiate(_content.DialoguePrefab, _mainCanvas.transform);
        }
    }
}