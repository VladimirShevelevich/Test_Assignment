using App.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.MainMenu
{
    [CreateAssetMenu(fileName = "MainMenuInstaller", menuName = "Installer/MainMenu")]
    public class MainMenuInstaller : Installer
    {
        [SerializeField] private MainMenuContent _content;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_content);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<MainMenuFactory>();
            });
            builder.Register<MainMenuPresenter>(Lifetime.Singleton);
        }
    }
}