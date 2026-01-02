using VContainer;
using VContainer.Unity;

namespace App.MagicWords
{
    public static class LoaderInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<IDataLoader, UrlDataLoader>(Lifetime.Scoped);
            builder.Register<DataParser>(Lifetime.Scoped);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<LoaderService>().AsSelf();
            });
        }
    }
}