using App.Tools;
using UnityEngine;

namespace App.MagicWords.Loading
{
    public class LoadingAnimationService : BaseDisposable, ILoadingAnimationService
    {
        private readonly DataLoadingContent _dataLoadingContent;
        private readonly Canvas _mainCanvas;
        private GameObject _loadingGo;

        public LoadingAnimationService(DataLoadingContent dataLoadingContent, Canvas mainCanvas)
        {
            _dataLoadingContent = dataLoadingContent;
            _mainCanvas = mainCanvas;
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
            _loadingGo = Object.Instantiate(_dataLoadingContent.LoadingPrefab, _mainCanvas.transform);
            LinkDisposable(new GameObjectDisposer(_loadingGo));
        }
    }
}