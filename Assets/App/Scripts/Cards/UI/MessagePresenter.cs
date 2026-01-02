using App.Tools;
using UnityEngine;
using VContainer.Unity;
using UniRx;

namespace App.Cards.UI
{
    public class MessagePresenter : BaseDisposable, IInitializable
    {
        private readonly Canvas _canvas;
        private readonly CardsContent _cardsContent;
        private readonly CardsMover _cardsMover;

        public MessagePresenter(Canvas canvas, CardsContent cardsContent, CardsMover cardsMover)
        {
            _canvas = canvas;
            _cardsContent = cardsContent;
            _cardsMover = cardsMover;
        }


        public void Initialize()
        {
            AddDisposable(_cardsMover.OnMovingComplete.Subscribe(_ => OnMovingComplete()));
        }

        private void OnMovingComplete()
        {
            ShowMessage();
        }

        private void ShowMessage()
        {
            var message = Object.Instantiate(_cardsContent.MessagePrefab, _canvas.transform);
            AddDisposable(new GameObjectDisposer(message));
        }
    }
}