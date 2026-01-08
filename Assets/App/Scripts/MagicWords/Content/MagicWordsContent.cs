using UnityEngine;
using VContainer;

namespace App.MagicWords
{
    [CreateAssetMenu(fileName = "MagicWordsContent", menuName = "Content/MagicWords/MagicWordsContent")]
    public class MagicWordsContent : ScriptableObject
    {
        [SerializeField] private DialogueContent _dialogueContent;
        [SerializeField] private DataLoadingContent _dataLoadingContent;

        public void Register(IContainerBuilder builder)
        {
            builder.RegisterInstance(_dialogueContent);
            builder.RegisterInstance(_dataLoadingContent);
        }
    }
}