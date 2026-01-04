using System;
using UnityEngine;
using Object = UnityEngine.Object;
using UniRx;

namespace App.MagicWords
{
    public class MessageService
    {
        private readonly Canvas _mainCanvas;
        private readonly MagicWordsContent _magicWordsContent;

        private MessageView _message;

        public MessageService(Canvas mainCanvas, MagicWordsContent magicWordsContent)
        {
            _mainCanvas = mainCanvas;
            _magicWordsContent = magicWordsContent;
        }
        
        public void ShowLoadingFailedMessage(Action onRepeatCalled)
        {
            CreateMessage(onRepeatCalled);
        }

        private void CreateMessage(Action onRepeatCalled)
        {
            _message = Object.Instantiate(_magicWordsContent.MessagePrefab, _mainCanvas.transform);
            _message.OnRepeatCalled.Subscribe(_ =>
            {
                onRepeatCalled.Invoke();
                HideMessage();
            });
        }

        private void HideMessage()
        {
            Object.Destroy(_message.gameObject);
        }
    }
}