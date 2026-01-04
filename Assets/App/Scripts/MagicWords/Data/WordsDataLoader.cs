using System;
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
        
        public async UniTask InitializeAsync()
        {
            while (true)
            {
                try
                {
                    await LoadData();
                    Debug.Log("Words data has been loaded");
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
            var json = await DataLoader.LoadJsonAsync(_magicWordsContent.DataUrl);
            Data = DataParser.Parse<WordsData>(json);
        }

        private async UniTask WaitUntilRepeatIsCalled()
        {
            var repeatIsCalled = false;
            ShowLoadingFailedMessage(onRepeatCalled: () => repeatIsCalled = true);
            await UniTask.WaitUntil(() => repeatIsCalled);
        }

        private void ShowLoadingFailedMessage(Action onRepeatCalled)
        {
            _messageService.ShowLoadingFailedMessage(onRepeatCalled);
        }
    }
}