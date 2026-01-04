using System;
using System.Threading;
using App.Scripts.Tools;
using App.Tools;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.MagicWords
{
    public class WordsDataLoader
    {
        public WordsData Data { get; private set; }
        
        private readonly MagicWordsContent _magicWordsContent;
        private readonly MessageService _messageService;

        public WordsDataLoader(MagicWordsContent magicWordsContent, MessageService messageService)
        {
            _magicWordsContent = magicWordsContent;
            _messageService = messageService;
        }
        
        public async UniTask InitializeAsync(CancellationToken ctsToken)
        {
            while (true)
            {
                try
                {
                    await LoadData(ctsToken);
                    Debug.Log("Words data has been loaded");
                    return;
                }
                catch (OperationCanceledException)
                {
                    Debug.Log($"Data loading has been canceled.");
                    throw;
                }        
                catch (Exception e)
                {
                    Debug.LogWarning($"Data loading has failed. {e}");
                    await WaitUntilRepeatIsCalled(ctsToken);
                }        
            }    
        }

        private async UniTask LoadData(CancellationToken token)
        {
            Debug.Log("Dialogue data loading");
            await UniTask.Delay(2000, cancellationToken: token);
            var json = await DataLoader.LoadJsonAsync(_magicWordsContent.DataUrl, token);
            Data = DataParser.Parse<WordsData>(json);
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
            _messageService.ShowLoadingFailedMessage(onRepeatCalled);
        }
    }
}