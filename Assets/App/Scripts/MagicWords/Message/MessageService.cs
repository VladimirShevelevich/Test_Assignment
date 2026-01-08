using System;
using App.Tools;
using UnityEngine;
using Object = UnityEngine.Object;
using UniRx;

namespace App.MagicWords
{
    public class MessageService : BaseDisposable
    {
        private readonly Canvas _mainCanvas;
        private readonly DataLoadingContent _dataLoadingContent;

        private MessageView _message;

        public MessageService(Canvas mainCanvas, DataLoadingContent dataLoadingContent)
        {
            _mainCanvas = mainCanvas;
            _dataLoadingContent = dataLoadingContent;
        }
        
        public void ShowLoadingFailedMessage(Action onRepeatCalled)
        {
            CreateMessage(onRepeatCalled);
        }

        private void CreateMessage(Action onRepeatCalled)
        {
            _message = Object.Instantiate(_dataLoadingContent.LoadingErrorMessagePrefab, _mainCanvas.transform);
            LinkDisposable(new GameObjectDisposer(_message.gameObject));
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