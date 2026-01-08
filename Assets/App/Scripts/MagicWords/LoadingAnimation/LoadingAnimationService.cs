using App.Tools;
using UnityEngine;

namespace App.MagicWords.Loading
{
    public class LoadingAnimationService : BaseDisposable
    {
        private readonly DataLoadingContent _dataLoadingContent;
        private GameObject _loadingGo;

        public LoadingAnimationService(DataLoadingContent dataLoadingContent)
        {
            _dataLoadingContent = dataLoadingContent;
        }
        
        public void ShowLoading()
        {
            if (_loadingGo == null) 
                CreateLoadingGo();
        }

        public void HideLoading()
        {
            if (_loadingGo != null)
                _loadingGo.SetActive(false);
        }

        private void CreateLoadingGo()
        {
            _loadingGo = Object.Instantiate(_dataLoadingContent.LoadingPrefab);
            LinkDisposable(new GameObjectDisposer(_loadingGo));
        }
    }
}