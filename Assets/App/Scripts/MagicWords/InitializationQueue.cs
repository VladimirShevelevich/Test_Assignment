using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace App.MagicWords
{
    public class InitializationQueue : IInitializable
    {
        private readonly WordsDataLoader _wordsDataLoader;

        public InitializationQueue(WordsDataLoader wordsDataLoader)
        {
            _wordsDataLoader = wordsDataLoader;
        }
        
        public void Initialize()
        {
            InitializeAsync();
        }

        private async UniTaskVoid InitializeAsync()
        {
            await _wordsDataLoader.InitializeAsync();
        }
    }
}