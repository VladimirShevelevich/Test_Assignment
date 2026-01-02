using App.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.Cards
{
    [CreateAssetMenu(fileName = "CardsInstaller", menuName = "Installer/Cards")]
    public class CardsInstaller : Installer
    {
        [SerializeField] private CardsContent _cardsContent;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<DeckFactory>(Lifetime.Scoped);
            builder.RegisterInstance(_cardsContent);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<CardsService>().AsSelf();
                ep.Add<CardsMover>();
            });
        }
    }
}