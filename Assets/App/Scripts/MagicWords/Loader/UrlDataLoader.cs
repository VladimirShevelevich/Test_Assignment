using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace App.MagicWords
{
    public class UrlDataLoader : IDataLoader
    {
        private readonly MagicWordsContent _content;
        private readonly DataParser _dataParser;

        public UrlDataLoader(MagicWordsContent content, DataParser dataParser)
        {
            _content = content;
            _dataParser = dataParser;
        }

        public async UniTask<WordsData> LoadDataAsync()
        {
            var json = await LoadJson();
            var data = _dataParser.Parse(json);
            return data;
        }

        private async Task<string> LoadJson()
        {
            var request = UnityWebRequest.Get(_content.DataUrl);
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
                throw new Exception(request.error);

            return request.downloadHandler.text;
        }
    }
}