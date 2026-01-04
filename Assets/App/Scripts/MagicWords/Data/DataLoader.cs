using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace App.MagicWords
{
    public static class DataLoader
    {
        public static async UniTask<string> LoadJsonAsync(string url)
        {
            using var request = UnityWebRequest.Get(url);
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
                throw new Exception(request.error);

            return request.downloadHandler.text;
        }
    }
}