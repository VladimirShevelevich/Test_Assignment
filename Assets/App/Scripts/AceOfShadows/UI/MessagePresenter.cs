using App.Tools;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace App.AceOfShadows
{
    public class MessagePresenter : BaseDisposable, IInitializable
    {
        private readonly Canvas _canvas;
        private readonly UiContent _uiContent;
        private readonly CardsService _cardsService;

        public MessagePresenter(Canvas canvas, UiContent uiContent, CardsService cardsService)
        {
            _canvas = canvas;
            _uiContent = uiContent;
            _cardsService = cardsService;
        }


        public void Initialize()
        {
            LinkDisposable(_cardsService.OnMovingComplete.Subscribe(_ => OnMovingComplete()));
        }

        private void OnMovingComplete()
        {
            ShowMessage();
        }

        private void ShowMessage()
        {
            var message = Object.Instantiate(_uiContent.MessagePrefab, _canvas.transform);
            LinkDisposable(new GameObjectDisposer(message));
        }
    }
}