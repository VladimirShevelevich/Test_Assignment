using App.MagicWords.Loading;
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
            _content.Register(builder);
            builder.Register<RemoteContentLoader>(Lifetime.Scoped);
            builder.Register<RemoteContentFetcher>(Lifetime.Scoped);
            builder.Register<ErrorMessageService>(Lifetime.Scoped);
            builder.Register<ILoadingAnimationService, LoadingAnimationService>(Lifetime.Scoped);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<InitializationQueue>();
            });
        }
    }
}