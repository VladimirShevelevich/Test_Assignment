using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.AceOfShadows
{
    public class CardsScope : LifetimeScope
    {
        [SerializeField] private AceOfShadowsContent _aceOfShadowsContent;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<DeckFactory>(Lifetime.Scoped);
            _aceOfShadowsContent.Register(builder);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<CardsService>().AsSelf();
                ep.Add<MessagePresenter>();
            });
        }
    }
}   