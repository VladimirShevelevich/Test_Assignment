using System;
using App.Tools;

namespace App.MagicWords
{
    /// <summary>
    /// A facade used by DialogueService
    /// </summary>
    public class Dialogue : BaseDisposable, IDialogue
    {
        private readonly DialoguePresenter _presenter;

        public Dialogue(DialoguePresenter presenter, DialogueView view)
        {
            _presenter = presenter;
            AddDisposable(presenter);         
            AddDisposable(new GameObjectDisposer(view.gameObject));         
        }

        public void StartDialogue()
        {
            _presenter.StartDialogue();
        }
    }

    public interface IDialogue : IDisposable
    {
        public void StartDialogue();
    }
}