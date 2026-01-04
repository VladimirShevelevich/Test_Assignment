using System;
using System.Threading;
using App.MagicWords.Loading;
using App.Scripts.Tools;
using App.Tools;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace App.MagicWords
{
    public class InitializationQueue : BaseDisposable, IInitializable
    {
        private readonly WordsDataLoader _wordsDataLoader;
        private readonly DialogueDataLoader _dialogueDataLoader;
        private readonly AvatarsDataLoader _avatarsDataLoader;
        private readonly LoadingService _loadingService;
        private readonly LifetimeScope _magicWordsScope;

        //Object dispose handling token
        private readonly CancellationTokenSource _cts = new();
        
        public InitializationQueue(WordsDataLoader wordsDataLoader, 
            DialogueDataLoader dialogueDataLoader, 
            AvatarsDataLoader avatarsDataLoader,
            LoadingService loadingService,
            LifetimeScope magicWordsScope)
        {
            _wordsDataLoader = wordsDataLoader;
            _dialogueDataLoader = dialogueDataLoader;
            _avatarsDataLoader = avatarsDataLoader;
            _loadingService = loadingService;
            _magicWordsScope = magicWordsScope;
        }
        
        public void Initialize()
        {
            AddDisposable(new TokenDisposer(_cts));
            InitializeAsync().Forget();
        }

        private async UniTaskVoid InitializeAsync()
        {
            _loadingService.ShowLoading();
            
            try
            {
                await _wordsDataLoader.InitializeAsync(_cts.Token);
                _dialogueDataLoader.Initialize();
                await _avatarsDataLoader.InitializeAsync(_cts.Token);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Initialization has been canceled");
            }
            
            Debug.Log("Initialization's compelted");
            _loadingService.HideLoading();
            CreateDialogueScope();
        }

        private void CreateDialogueScope()
        {
            var scope = _magicWordsScope.CreateChild<DialogueScope>();
            scope.name = "DialogueScope";
        }
    }
}