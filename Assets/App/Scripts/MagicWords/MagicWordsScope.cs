using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.MagicWords
{
    public class MagicWordsScope : LifetimeScope
    {
        [SerializeField] private MagicWordsContent _content;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_content);
            LoaderInstaller.Install(builder);
            DialogueInstaller.Install(builder);
        }
    }
}