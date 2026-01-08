using App.Tools;
using UnityEngine;
using VContainer.Unity;

namespace App.FPS
{
    public class FpsPresenter : BaseDisposable, IInitializable
    {
        private readonly Canvas _mainCanvas;
        private readonly FpsContent _fpsContent;

        public FpsPresenter(Canvas mainCanvas, FpsContent fpsContent)
        {
            _mainCanvas = mainCanvas;
            _fpsContent = fpsContent;
        }
        
        public void Initialize()
        {
            CreateView();
        }

        private void CreateView()
        {
            var view = Object.Instantiate(_fpsContent.FpsPrefab, _mainCanvas.transform);
            LinkDisposable(new GameObjectDisposer(view));
        }
    }
}
