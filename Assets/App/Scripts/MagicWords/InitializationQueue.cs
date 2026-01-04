using System;
using System.Threading;
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

        //Object dispose handling token
        private readonly CancellationTokenSource _cts = new();
        
        public InitializationQueue(WordsDataLoader wordsDataLoader, DialogueDataLoader dialogueDataLoader)
        {
            _wordsDataLoader = wordsDataLoader;
            _dialogueDataLoader = dialogueDataLoader;
        }
        
        public void Initialize()
        {
            AddDisposable(new TokenDisposer(_cts));
            InitializeAsync().Forget();
        }

        private async UniTaskVoid InitializeAsync()
        {
            try
            {
                await _wordsDataLoader.InitializeAsync(_cts.Token);
                _dialogueDataLoader.Initialize();
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Initialization has been canceled");
            }
        }
    }
}