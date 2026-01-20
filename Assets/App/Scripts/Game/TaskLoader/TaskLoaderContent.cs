using UnityEngine;
using VContainer.Unity;

namespace App.TaskLoader
{
    [CreateAssetMenu(fileName = "TaskLoaderContent", menuName = "Content/TaskLoader")]
    public class TaskLoaderContent : ScriptableObject
    {
        /// <summary>
        /// The task loading is handled by the prefabs order
        /// </summary>
        [field: SerializeField] public LifetimeScope[] TasksScopes { get; private set; }
    }
}