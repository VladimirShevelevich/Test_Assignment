using App.Core;
using UnityEngine;
using VContainer;

namespace App.TaskLoader
{
    [CreateAssetMenu(fileName = "TaskLoaderInstaller", menuName = "Installer/TaskLoader")]
    public class TaskLoaderInstaller : Installer
    {
        [SerializeField] private TaskLoaderContent _taskLoaderContent;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<TaskLoaderService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterInstance(_taskLoaderContent);
        }
    }
}