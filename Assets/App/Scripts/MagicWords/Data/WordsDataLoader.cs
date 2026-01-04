using System;
using System.Threading;
using App.Scripts.Tools;
using App.Tools;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.MagicWords
{
    public class WordsDataLoader : BaseDisposable
    {
        public WordsData Data { get; private set; }
        
        private readonly MagicWordsContent _magicWordsContent;
        private readonly MessageService _messageService;

        //Object dispose handling token
        private readonly CancellationTokenSource _cts = new();

        public WordsDataLoader(MagicWordsContent magicWordsContent, MessageService messageService)
        {
            _magicWordsContent = magicWordsContent;
            _messageService = messageService;
        }
        
        public async UniTask InitializeAsync()
        {
            AddDisposable(new TokenDisposer(_cts));
            
            while (true)
            {
                try
                {
                    await LoadData();
                    Debug.Log("Words data has been loaded");
                    return;
                }
                catch (OperationCanceledException e)
                {
                    Debug.Log($"Data loading has been canceled.");
                    return;
                }        
                catch (Exception e)
                {
                    Debug.LogWarning($"Data loading has failed. {e}");
                    await WaitUntilRepeatIsCalled();
                }        
            }    
        }

        private async UniTask LoadData()
        {
            Debug.Log("Dialogue data loading");
            await UniTask.Delay(2000, cancellationToken: _cts.Token);
            var json = await DataLoader.LoadJsonAsync(_magicWordsContent.DataUrl, _cts.Token);
            Data = DataParser.Parse<WordsData>(json);
        }

        private async UniTask WaitUntilRepeatIsCalled()
        {
            var repeatIsCalled = false;
            ShowLoadingFailedMessage(onRepeatCalled: () => repeatIsCalled = true);
            await UniTask.WaitUntil(() => repeatIsCalled, 
                cancellationToken: _cts.Token);
        }

        private void ShowLoadingFailedMessage(Action onRepeatCalled)
        {
            _messageService.ShowLoadingFailedMessage(onRepeatCalled);
        }
    }
}