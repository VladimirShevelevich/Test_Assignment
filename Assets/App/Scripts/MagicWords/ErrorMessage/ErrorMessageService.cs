using System;
using App.Tools;
using UnityEngine;
using Object = UnityEngine.Object;
using UniRx;

namespace App.MagicWords
{
    public class ErrorMessageService : BaseDisposable
    {
        private readonly Canvas _mainCanvas;
        private readonly DataLoadingContent _dataLoadingContent;

        private ErrorMessageView _errorMessage;

        public ErrorMessageService(Canvas mainCanvas, DataLoadingContent dataLoadingContent)
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
            _errorMessage = Object.Instantiate(_dataLoadingContent.LoadingErrorErrorMessagePrefab, _mainCanvas.transform);
            LinkDisposable(new GameObjectDisposer(_errorMessage.gameObject));
            _errorMessage.OnRepeatCalled.Subscribe(_ =>
            {
                onRepeatCalled.Invoke();
                HideMessage();
            });
        }

        private void HideMessage()
        {
            Object.Destroy(_errorMessage.gameObject);
        }
    }
}