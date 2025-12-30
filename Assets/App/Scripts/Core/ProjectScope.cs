using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.Core
{
    public class ProjectScope : LifetimeScope
    {
        [SerializeField] private Installer[] _installers;
        
        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _installers) 
                installer.Install(builder);
        }
    }
}