using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using App.Scripts.MagicWords;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.MagicWords
{
    public class AvatarsDataLoader
    {
        public List<AvatarData> Datas { get; private set; } = new();
        
        private readonly WordsDataLoader _wordsDataLoader;
        private readonly MagicWordsContent _wordsContent;

        public AvatarsDataLoader(WordsDataLoader wordsDataLoader, MagicWordsContent wordsContent)
        {
            _wordsDataLoader = wordsDataLoader;
            _wordsContent = wordsContent;
        }
        
        public async UniTask InitializeAsync(CancellationToken ctsToken)
        {
            await LoadDataAsync(ctsToken);
        }

        private async UniTask LoadDataAsync(CancellationToken ctsToken)
        {
            Debug.Log("Avatars data loading");
            var wordsData = _wordsDataLoader.Data;

            var avatarLoadOperations = wordsData.avatars.Select(remoteData => 
                CreateAvatarData(remoteData, ctsToken)).ToList();

            var datas = await UniTask.WhenAll(avatarLoadOperations);
            foreach (var data in datas)
            {
                if (Datas.Any(x => x.Name == data.Name))
                {
                    Debug.LogWarning($"{data.Name} avatar data is duplicated");
                    continue;
                }

                Datas.Add(data);
            }
        }

        private async UniTask<AvatarData> CreateAvatarData(WordsData.Avatar remoteData, CancellationToken token)
        {
            Texture2D texture;
            try
            {
                texture = await LoadTexture(remoteData.url, token);
            }
            catch (Exception e) when (e is not OperationCanceledException)
            {
                Debug.LogWarning($"Failed to load avatar {remoteData.name} texture. {e}");
                texture = _wordsContent.AvatarDefaultTexture;
            }

            return new AvatarData(
                name: remoteData.name,
                texture: texture,
                position: remoteData.position == "right" ? AvatarPosition.right : AvatarPosition.left);
        }

        private async UniTask<Texture2D> LoadTexture(string url, CancellationToken token)
        {
            return await DataLoader.LoadTextureAsync(url, token);
        }
    }

    public enum AvatarPosition
    {
        right,
        left
    }
}