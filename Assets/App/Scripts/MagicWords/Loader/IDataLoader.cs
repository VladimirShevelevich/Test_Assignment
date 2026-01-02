using Cysharp.Threading.Tasks;

namespace App.MagicWords
{
    public interface IDataLoader
    {
        UniTask<WordsData> LoadDataAsync();
    }
}