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
        private readonly AvatarsDataLoader _avatarsDataLoader;
        private readonly RemoteContentFetcher _remoteContentFetcher;
        private readonly LoadingService _loadingService;
        private readonly LifetimeScope _magicWordsScope;

        //Object dispose handling token
        private readonly CancellationTokenSource lifetimeCts = new();
        
        public InitializationQueue(RemoteContentFetcher remoteContentFetcher,
            LoadingService loadingService,
            LifetimeScope magicWordsScope)
        {
            _remoteContentFetcher = remoteContentFetcher;
            _loadingService = loadingService;
            _magicWordsScope = magicWordsScope;
        }
        
        public void Initialize()
        {
            AddDisposable(new TokenDisposer(lifetimeCts));
            InitializeAsync().Forget();
        }

        private async UniTaskVoid InitializeAsync()
        {
            _loadingService.ShowLoading();
            
            try
            {
                await _remoteContentFetcher.FetchAsync(lifetimeCts.Token);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Initialization has been canceled");
                return;
            }
            
            Debug.Log("Initialization has been completed");
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