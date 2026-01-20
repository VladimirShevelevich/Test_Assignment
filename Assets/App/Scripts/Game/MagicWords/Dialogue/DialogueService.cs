using App.Tools;
using VContainer.Unity;

namespace App.MagicWords
{
    public class DialogueService : BaseDisposable, IInitializable
    {
        private readonly DialogueFactory _dialogueFactory;

        public DialogueService(DialogueFactory dialogueFactory)
        {
            _dialogueFactory = dialogueFactory;
        }
        
        public void Initialize()
        {
            var dialogue = _dialogueFactory.Create();
            LinkDisposable(dialogue);
            dialogue.StartDialogue();
        }
    }
}