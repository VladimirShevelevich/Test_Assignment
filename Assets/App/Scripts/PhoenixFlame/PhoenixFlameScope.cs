using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.PhoenixFlame
{
    public class PhoenixFlameScope : LifetimeScope
    {
        [SerializeField] private PhoenixFlameContent _content;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_content);
            builder.Register<FlameFactory>(Lifetime.Scoped);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<FlameService>();
            });
        }
    }
}