using VContainer;
using VContainer.Unity;

namespace App.MagicWords
{
    public static class DialogueInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<DialogueFactory>(Lifetime.Scoped);
            builder.Register<AvatarLoader>(Lifetime.Scoped);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<DialoguePresenter>();
            });
        }
    }
}