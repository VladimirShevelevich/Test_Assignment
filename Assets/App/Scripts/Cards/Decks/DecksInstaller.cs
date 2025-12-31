using App.Cards;
using App.Cards.Deck;
using App.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.Scripts.Cards.Decks
{
    [CreateAssetMenu(fileName = "DecksInstaller", menuName = "Installer/Decks")]
    public class DecksInstaller : Installer
    {
        [SerializeField] private DecksContent _decksContent;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<DeckFactory>(Lifetime.Scoped);
            builder.RegisterInstance(_decksContent);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<DecksService>().AsSelf();
                ep.Add<CardsMover>();
            });
        }
    }
}