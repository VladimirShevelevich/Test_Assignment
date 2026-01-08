using App.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.FPS
{
    [CreateAssetMenu(fileName = "FpsInstaller", menuName = "Installer/Fps")]
    public class FpsInstaller : Installer
    {
        [SerializeField] private FpsContent _fpsContent;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_fpsContent);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<FpsPresenter>();
            });
        }
    }
}