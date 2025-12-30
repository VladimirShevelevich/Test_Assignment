using App.Core;
using UnityEngine;
using VContainer;

namespace App.TaskLoader
{
    [CreateAssetMenu(fileName = "TaskLoaderInstaller", menuName = "Installer/TaskLoader")]
    public class TaskLoaderInstaller : Installer
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<TaskLoaderService>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}