using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.MagicWords
{
    public class RemoteContentFetcher
    {
        private readonly RemoteContentLoader _remoteContentLoader;
        private readonly MessageService _messageService;
        private readonly DataLoadingContent _dataLoadingContent;
        private readonly DialogueContent _dialogueContent;

        public RemoteContentFetcher(DataLoadingContent dataLoadingContent, DialogueContent dialogueContent, RemoteContentLoader remoteContentLoader)
        {
            _dataLoadingContent = dataLoadingContent;
            _dialogueContent = dialogueContent;
            _remoteContentLoader = remoteContentLoader;
        }

        public async UniTask FetchAsync(CancellationToken lifetimeToken)
        {
            var remoteData = await _remoteContentLoader.LoadDataAsync(_dataLoadingContent.DataUrl, lifetimeToken);
            FetchDialogueData(remoteData);
            await FetchAvatarsDataAsync(remoteData, lifetimeToken);
        }

        private void FetchDialogueData(RemoteData remoteData)
        {
            _dialogueContent.Dialogues = remoteData.dialogue.ToList();
        }

        private async UniTask FetchAvatarsDataAsync(RemoteData remoteData, CancellationToken lifetimeToken)
        {
            var avatarDataLoader = new AvatarsDataLoader();
            _dialogueContent.Avatars = await avatarDataLoader.LoadDataAsync(remoteData, lifetimeToken);
        }
    }
}