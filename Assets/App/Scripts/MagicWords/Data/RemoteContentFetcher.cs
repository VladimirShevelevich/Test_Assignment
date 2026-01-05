using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.MagicWords
{
    public class RemoteContentFetcher
    {
        private readonly MagicWordsContent _content;
        private readonly RemoteContentLoader _remoteContentLoader;
        private readonly MessageService _messageService;

        public RemoteContentFetcher(MagicWordsContent content, RemoteContentLoader remoteContentLoader)
        {
            _content = content;
            _remoteContentLoader = remoteContentLoader;
        }

        public async UniTask FetchAsync(CancellationToken lifetimeToken)
        {
            var remoteData = await _remoteContentLoader.LoadDataAsync(_content.DataUrl, lifetimeToken);
            FetchDialogueData(remoteData);
            await FetchAvatarsDataAsync(remoteData, lifetimeToken);
        }

        private void FetchDialogueData(RemoteData remoteData)
        {
            _content.Dialogues = remoteData.dialogue.ToList();
        }

        private async UniTask FetchAvatarsDataAsync(RemoteData remoteData, CancellationToken lifetimeToken)
        {
            var avatarDataLoader = new AvatarsDataLoader(_content.AvatarDefaultTexture);
            _content.Avatars = await avatarDataLoader.LoadDataAsync(remoteData, lifetimeToken);
        }
    }
}