using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.MainMenu
{
    public class MainMenuFactory : IInitializable
    {
        private readonly MainMenuContent _mainMenuContent;
        private readonly Canvas _mainCanvas;
        private readonly IObjectResolver _objectResolver;

        public MainMenuFactory(MainMenuContent mainMenuContent, Canvas mainCanvas, IObjectResolver objectResolver)
        {
            _mainMenuContent = mainMenuContent;
            _mainCanvas = mainCanvas;
            _objectResolver = objectResolver;
        }
        
        public void Initialize()
        {
            var view = CreateView();
            var presenter = _objectResolver.Resolve<MainMenuPresenter>();
            presenter.BindView(view);
        }

        private MainMenuView CreateView()
        {
            return Object.Instantiate(_mainMenuContent.ViewPrefab, _mainCanvas.transform);
        }
    }
}