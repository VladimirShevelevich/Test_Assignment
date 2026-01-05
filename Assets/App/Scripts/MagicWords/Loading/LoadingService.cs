using App.Tools;
using UnityEngine;

namespace App.MagicWords.Loading
{
    public class LoadingService : BaseDisposable
    {
        private readonly MagicWordsContent _magicWordsContent;
        private GameObject _loadingGo;

        public LoadingService(MagicWordsContent magicWordsContent)
        {
            _magicWordsContent = magicWordsContent;
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
            _loadingGo = Object.Instantiate(_magicWordsContent.LoadingPrefab);
            LinkDisposable(new GameObjectDisposer(_loadingGo));
        }
    }
}