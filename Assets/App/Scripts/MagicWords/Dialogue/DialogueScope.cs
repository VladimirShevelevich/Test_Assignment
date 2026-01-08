using VContainer;
using VContainer.Unity;

namespace App.MagicWords
{
    public class DialogueScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<DialogueFactory>(Lifetime.Scoped);
            builder.Register<DialoguePresenter>(Lifetime.Transient);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<DialogueService>();
            });
        }
    }
}