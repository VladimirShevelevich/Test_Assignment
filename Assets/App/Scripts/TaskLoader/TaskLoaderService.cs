using UnityEngine;
using VContainer.Unity;

namespace App.TaskLoader
{
    public class TaskLoaderService : IInitializable, ITaskLoaderService
    {
        private int _currentTaskIndex = -1;
        
        public void Initialize()
        {
            LoadTask(0);
        }

        public void LoadTask(int taskIndex)
        {
            if (taskIndex == _currentTaskIndex)
            {
                Debug.Log($"The task {taskIndex} is already loaded");
                return;
            }
            
            Debug.Log($"Loading task by index {taskIndex}");
            _currentTaskIndex = taskIndex;
        }
    }
}