using System;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace App.PhoenixFlame.UI
{
    public class UiView : MonoBehaviour
    {
        public IObservable<Unit> OnStartAnimationClick => _onStartAnimationClick;
        private readonly ReactiveCommand _onStartAnimationClick = new();

        [SerializeField] private Button _button;
        
        private void Start()
        {
            _button.OnClickAsObservable().Subscribe(_ =>
            {
                _onStartAnimationClick?.Execute();
            }).AddTo(this);
        }

        public void HideButton()
        {
            _button.transform.DOScale(0, 0.1f).SetLink(gameObject);
        }
    }
}