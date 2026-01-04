using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace App.MagicWords
{
    public static class DataLoader
    {
        public static async UniTask<string> LoadJsonAsync(string url, CancellationToken token)
        {
            using var request = UnityWebRequest.Get(url);
            await request.SendWebRequest().
                ToUniTask(cancellationToken: token);
            
            token.ThrowIfCancellationRequested();

            if (request.result != UnityWebRequest.Result.Success)
                throw new Exception(request.error);

            return request.downloadHandler.text;
        }
        
        public static async UniTask<Texture2D> LoadTextureAsync(string url, CancellationToken token)
        {
            using var request = UnityWebRequestTexture.GetTexture(url);
            await request.SendWebRequest().
                ToUniTask(cancellationToken: token);
            
            token.ThrowIfCancellationRequested();

            if (request.result != UnityWebRequest.Result.Success)
                throw new Exception(request.error);

            return DownloadHandlerTexture.GetContent(request);
        }
    }
}