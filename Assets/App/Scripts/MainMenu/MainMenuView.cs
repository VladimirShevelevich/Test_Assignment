using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace App.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        public IObservable<int> OnTaskBtnClick => _onTaskBtnClick;
        private readonly ReactiveCommand<int> _onTaskBtnClick = new();
        
        [SerializeField] private Button[] _tasksButtons;

        private void Start()
        {
            SubscribeOnButtonsClicks();
        }

        private void SubscribeOnButtonsClicks()
        {
            for (var i = 0; i < _tasksButtons.Length; i++)
            {
                var taskIndex = i;
                _tasksButtons[i].onClick.AddListener(() =>
                {
                    _onTaskBtnClick.Execute(taskIndex);
                });                
            }
        }
    }
}