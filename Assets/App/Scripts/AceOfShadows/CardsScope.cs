using App.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.AceOfShadows
{
    public class CardsScope : LifetimeScope
    {
        [SerializeField] private Installer[] _installers;

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _installers)
            {
                installer.Install(builder);
            }
        }
    }
}   