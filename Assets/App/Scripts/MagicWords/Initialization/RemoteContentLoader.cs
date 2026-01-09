using System;
using System.Threading;
using App.Tools;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.MagicWords
{
    /// <summary>
    /// Loads remote data and display the error message
    /// </summary>
    public class RemoteContentLoader
    {
        private readonly ErrorMessageService _errorMessageService;

        public RemoteContentLoader(ErrorMessageService errorMessageService)
        {
            _errorMessageService = errorMessageService;
        }
        
        public async UniTask<RemoteData> LoadDataAsync(string url, CancellationToken ctsToken)
        {
            while (true)
            {
                try
                {
                    var data = await LoadDataAsyncInternal(url, ctsToken);
                    Debug.Log("Remote data has been loaded");
                    return data;
                }
                catch (Exception e) when (e is not OperationCanceledException)
                {
                    Debug.LogWarning($"Data loading has failed. {e}");
                    await WaitUntilRepeatIsCalled(ctsToken);
                }        
            }    

        }        
        
        private async UniTask<RemoteData> LoadDataAsyncInternal(string url, CancellationToken token)
        {
            Debug.Log("Remote data loading");
            var json = await UrlDataLoader.LoadJsonAsync(url, token);
            var data = DataParser.Parse<RemoteData>(json);
            return data;
        }

        private async UniTask WaitUntilRepeatIsCalled(CancellationToken token)
        {
            var repeatIsCalled = false;
            ShowLoadingFailedMessage(onRepeatCalled: () => repeatIsCalled = true);
            await UniTask.WaitUntil(() => repeatIsCalled, 
                cancellationToken: token);
        }

        private void ShowLoadingFailedMessage(Action onRepeatCalled)
        {
            _errorMessageService.ShowLoadingFailedMessage(onRepeatCalled);
        }
    }
}