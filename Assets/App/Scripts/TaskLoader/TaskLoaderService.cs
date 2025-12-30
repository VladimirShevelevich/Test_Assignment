using System;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace App.TaskLoader
{
    public class TaskLoaderService : IInitializable, ITaskLoaderService
    {
        private readonly TaskLoaderContent _taskLoaderContent;
        private readonly LifetimeScope _projectScope;
        private int _currentTaskIndex = -1;
        private IDisposable _currentTaskScope;

        public TaskLoaderService(TaskLoaderContent taskLoaderContent, LifetimeScope projectScope)
        {
            _taskLoaderContent = taskLoaderContent;
            _projectScope = projectScope;
        }
        
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

            _currentTaskScope?.Dispose();
            
            var scopePrefab = _taskLoaderContent.TasksScopes[taskIndex];
            _currentTaskScope = _projectScope.CreateChildFromPrefab(scopePrefab);
            _currentTaskIndex = taskIndex;
            Debug.Log($@"Task {taskIndex+1} has been loaded");
        }
    }
}