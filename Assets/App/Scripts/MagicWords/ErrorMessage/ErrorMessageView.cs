using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace App.MagicWords
{
    public class ErrorMessageView : MonoBehaviour
    {
        public IObservable<Unit> OnRepeatCalled => _onRepeatCalled;
        private readonly ReactiveCommand _onRepeatCalled = new();

        [SerializeField] private Button _repeatButton;

        private void Start()
        {
            _repeatButton.OnClickAsObservable().Subscribe(_ =>
            {
                _onRepeatCalled?.Execute();
            }).AddTo(this);
        }
    }
}