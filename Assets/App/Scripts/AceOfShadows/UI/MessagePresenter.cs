using App.Tools;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace App.AceOfShadows
{
    public class MessagePresenter : BaseDisposable, IInitializable
    {
        private readonly Canvas _canvas;
        private readonly CardsContent _cardsContent;
        private readonly CardsService _cardsService;

        public MessagePresenter(Canvas canvas, CardsContent cardsContent, CardsService cardsService)
        {
            _canvas = canvas;
            _cardsContent = cardsContent;
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
            var message = Object.Instantiate(_cardsContent.MessagePrefab, _canvas.transform);
            LinkDisposable(new GameObjectDisposer(message));
        }
    }
}