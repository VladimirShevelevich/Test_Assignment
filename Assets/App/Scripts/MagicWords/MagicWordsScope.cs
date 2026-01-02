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
            builder.Register<IDataLoader, UrlDataLoader>(Lifetime.Scoped);
            builder.Register<DataParser>(Lifetime.Scoped);
        }
    }
}