using UnityEngine;
using VContainer.Unity;

namespace App.MainMenu
{
    public class MainMenuFactory : IInitializable
    {
        private readonly MainMenuContent _mainMenuContent;
        private readonly Canvas _mainCanvas;

        public MainMenuFactory(MainMenuContent mainMenuContent, Canvas mainCanvas)
        {
            _mainMenuContent = mainMenuContent;
            _mainCanvas = mainCanvas;
        }
        
        public void Initialize()
        {
            CreateView();
        }

        private void CreateView()
        {
            Object.Instantiate(_mainMenuContent.ViewPrefab, _mainCanvas.transform);
        }
    }
}