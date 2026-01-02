using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace App.MagicWords
{
    public class AvatarLoader
    {
        public async UniTask<Texture2D> LoadAvatarAsync(string url)
        {
            using var request = UnityWebRequestTexture.GetTexture(url);
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
                throw new Exception(request.error);

            return DownloadHandlerTexture.GetContent(request);
        }
    }
}