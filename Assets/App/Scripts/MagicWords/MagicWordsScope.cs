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
            builder.Register<WordsDataLoader>(Lifetime.Scoped);
            builder.Register<DialogueDataLoader>(Lifetime.Scoped);
            builder.Register<AvatarsDataLoader>(Lifetime.Scoped);
            builder.Register<MessageService>(Lifetime.Scoped);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<InitializationQueue>();
            });
        }
    }
}