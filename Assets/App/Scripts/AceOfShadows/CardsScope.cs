using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.AceOfShadows
{
    public class CardsScope : LifetimeScope
    {
        [SerializeField] private CardsContent _cardsContent;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<DeckFactory>(Lifetime.Scoped);
            builder.RegisterInstance(_cardsContent);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<CardsService>().AsSelf();
                ep.Add<MessagePresenter>();
            });
        }
    }
}   