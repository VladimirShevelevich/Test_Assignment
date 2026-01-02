using UnityEngine;

namespace App.MagicWords
{
    [CreateAssetMenu(fileName = "MagicWordsContent", menuName = "Content/MagicWords")]
    public class MagicWordsContent : ScriptableObject
    {
        [field: SerializeField] public string DataUrl { get; private set; }
        [field: SerializeField] public DialogueView DialoguePrefab { get; private set; }
    }
}