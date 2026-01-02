using App.Tools;
using VContainer.Unity;
using UniRx;

namespace App.MagicWords
{
    public class DialoguePresenter :  BaseDisposable, IInitializable
    {
        private readonly LoaderService _loaderService;
        private readonly DialogueFactory _dialogueFactory;

        public DialoguePresenter(LoaderService loaderService, DialogueFactory dialogueFactory)
        {
            _loaderService = loaderService;
            _dialogueFactory = dialogueFactory;
        }
        
        public void Initialize()
        {
            AddDisposable(
                _loaderService.OnDataLoaded.Subscribe(OnDataLoaded));
        }

        private void OnDataLoaded(WordsData wordsData)
        {
            var view = _dialogueFactory.CreateDialogueView();
            AddDisposable(new GameObjectDisposer(view.gameObject));

            view.Show(wordsData);
        }
    }
}