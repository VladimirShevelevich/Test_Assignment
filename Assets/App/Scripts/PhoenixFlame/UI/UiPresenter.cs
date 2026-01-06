using App.Tools;
using UnityEngine;
using VContainer.Unity;
using UniRx;

namespace App.PhoenixFlame.UI
{
    public class UiPresenter : BaseDisposable, IInitializable
    {
        private readonly PhoenixFlameContent _content;
        private readonly Canvas _uiCanvas;
        private readonly FlameService _flameService;

        public UiPresenter(PhoenixFlameContent content, Canvas uiCanvas, FlameService flameService)
        {
            _content = content;
            _uiCanvas = uiCanvas;
            _flameService = flameService;
        }
        
        public void Initialize()
        {
            CreateView();
        }

        private void CreateView()
        {
            var view = Object.Instantiate(_content.UiView, _uiCanvas.transform);
            LinkDisposable(new GameObjectDisposer(view));

            SubscribeOnButtonClick(view);
        }

        private void SubscribeOnButtonClick(UiView view)
        {
            LinkDisposable(
                view.OnStartAnimationClick.Subscribe(_ => OnStartAnimationClick()));
        }

        private void OnStartAnimationClick()
        {
            _flameService.StartAnimation();
        }
    }
}