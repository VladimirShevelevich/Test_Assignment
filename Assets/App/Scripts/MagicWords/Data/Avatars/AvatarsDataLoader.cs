using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using App.Scripts.MagicWords;
using App.Tools;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.MagicWords
{
    public class AvatarsDataLoader
    {
        public async UniTask<List<AvatarData>> LoadDataAsync(RemoteData remoteData, CancellationToken ctsToken)
        {
            Debug.Log("Avatars data loading");
            List<AvatarData> datas = new();
            
            var avatarLoadOperations = remoteData.avatars.Select(remoteData => 
                LoadAvatarData(remoteData, ctsToken)).ToList();

            var loadedDatas = await UniTask.WhenAll(avatarLoadOperations);
            foreach (var loadedData in loadedDatas)
            {
                if (datas.Any(x => x.Name == loadedData.Name))
                {
                    Debug.LogWarning($"{loadedData.Name} avatar data is duplicated. The data's been overridden");
                    var original = datas.First(x => x.Name == loadedData.Name);
                    AvatarDataDuplicateHandler.HandleDuplicate(original, loadedData);
                }
                datas.Add(loadedData);
            }

            return datas;
        }

        private async UniTask<AvatarData> LoadAvatarData(RemoteData.Avatar remoteData, CancellationToken token)
        {
            Texture2D texture = null;
            try
            {
                texture = await LoadTextureAsync(remoteData.url, token);
            }
            catch (Exception e) when (e is not OperationCanceledException)
            {
                Debug.LogWarning($"Failed to load avatar {remoteData.name} texture. {e}. Using default ");
            }

            Sprite sprite = null;
            if (texture != null)
            {
                sprite = CreateSpriteFromTexture(texture);
            }

            var position = GetPosition(remoteData);

            return new AvatarData
            {
                Name = remoteData.name,
                Sprite = sprite,
                Position = position
            };
        }

        private AvatarPosition GetPosition(RemoteData.Avatar remoteData)
        {
            AvatarPosition position;
            switch (remoteData.position)
            {
                case "right":
                    position = AvatarPosition.right;
                    break;
                case "left":
                    position = AvatarPosition.left;
                    break;
                default:
                    Debug.LogError($"Failed to parse avatar {remoteData.name} position. Using default");
                    position = AvatarPosition.left;
                    break;
            }

            return position;
        }

        private async UniTask<Texture2D> LoadTextureAsync(string url, CancellationToken token)
        {
            return await UrlDataLoader.LoadTextureAsync(url, token);
        }

        private static Sprite CreateSpriteFromTexture(Texture2D texture)
        {
            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));
        }
    }

    public enum AvatarPosition
    {
        right,
        left
    }
}