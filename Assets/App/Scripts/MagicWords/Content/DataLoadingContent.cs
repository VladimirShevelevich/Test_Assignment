using UnityEngine;

namespace App.MagicWords
{
    [CreateAssetMenu(fileName = "DataLoadingContent", menuName = "Content/MagicWords/DataLoading")]
    public class DataLoadingContent : ScriptableObject
    {
        [field: SerializeField] public string DataUrl { get; private set; }
        [field: SerializeField] public MessageView LoadingErrorMessagePrefab { get; private set; }
        [field: SerializeField] public GameObject LoadingPrefab { get; private set; }
    }
}