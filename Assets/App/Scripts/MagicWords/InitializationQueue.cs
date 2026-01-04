using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace App.MagicWords
{
    public class InitializationQueue : IInitializable
    {
        private readonly WordsDataLoader _wordsDataLoader;
        private readonly DialogueDataLoader _dialogueDataLoader;

        public InitializationQueue(WordsDataLoader wordsDataLoader, DialogueDataLoader dialogueDataLoader)
        {
            _wordsDataLoader = wordsDataLoader;
            _dialogueDataLoader = dialogueDataLoader;
        }
        
        public void Initialize()
        {
            InitializeAsync().Forget();
        }

        private async UniTaskVoid InitializeAsync()
        {
            await _wordsDataLoader.InitializeAsync();
            _dialogueDataLoader.Initialize();
        }
    }
}