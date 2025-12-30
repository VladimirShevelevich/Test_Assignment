using UnityEngine;
using VContainer;

namespace App.Core
{
    public abstract class Installer : ScriptableObject
    {
        public abstract void Install(IContainerBuilder builder);
    }
}