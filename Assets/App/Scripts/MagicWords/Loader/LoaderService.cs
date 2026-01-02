using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace App.MagicWords
{
    public class LoaderService : IInitializable
    {
        public IObservable<WordsData> OnDataLoaded => _onDataLoaded;
        private readonly ReactiveCommand<WordsData> _onDataLoaded = new();
        
        private readonly IDataLoader _dataLoader;

        public LoaderService(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }
        
        public void Initialize()
        {
            InitializeAsync();
        }

        private async UniTaskVoid InitializeAsync()
        {
            try
            {
                var data = await _dataLoader.LoadDataAsync();
                _onDataLoaded?.Execute(data);
            }
            catch (Exception e)
            {
                Debug.LogError($"Data loading has failed. {e}");
            }
        }
    }
}