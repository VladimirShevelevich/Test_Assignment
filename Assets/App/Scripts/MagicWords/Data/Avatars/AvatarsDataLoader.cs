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
                CreateAvatarData(remoteData, ctsToken)).ToList();

            var loadedDatas = await UniTask.WhenAll(avatarLoadOperations);
            foreach (var loadedData in loadedDatas)
            {
                if (loadedData == null)
                    continue;
                
                if (datas.Any(x => x.Name == loadedData.Name))
                {
                    Debug.LogWarning($"{loadedData.Name} avatar data is duplicated");
                    continue;
                }

                datas.Add(loadedData);
            }

            return datas;
        }

        private async UniTask<AvatarData> CreateAvatarData(RemoteData.Avatar remoteData, CancellationToken token)
        {
            Texture2D texture;
            try
            {
                texture = await LoadTexture(remoteData.url, token);
            }
            catch (Exception e) when (e is not OperationCanceledException)
            {
                Debug.LogWarning($"Failed to load avatar {remoteData.name} texture. {e}. Using default ");
                return null;
            }

            var sprite = CreateSprite(texture);
            
            return new AvatarData(
                name: remoteData.name,
                sprite: sprite,
                position: remoteData.position == "right" ? AvatarPosition.right : AvatarPosition.left);
        }

        private static Sprite CreateSprite(Texture2D texture)
        {
            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));
        }

        private async UniTask<Texture2D> LoadTexture(string url, CancellationToken token)
        {
            return await UrlDataLoader.LoadTextureAsync(url, token);
        }
    }

    public enum AvatarPosition
    {
        right,
        left
    }
}