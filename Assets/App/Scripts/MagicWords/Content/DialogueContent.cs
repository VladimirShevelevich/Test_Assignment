using System.Collections.Generic;
using App.Scripts.MagicWords;
using UnityEngine;

namespace App.MagicWords
{
    [CreateAssetMenu(fileName = "DialogueContent", menuName = "Content/MagicWords/Dialogue")]
    public class DialogueContent : ScriptableObject
    {
        [field: SerializeField] public DialogueView DialoguePrefab { get; private set; }
        [field: SerializeField] public DialogueLine DialogueLineLeft { get; private set; }
        [field: SerializeField] public DialogueLine DialogueLineRight { get; private set; }
        [field: SerializeField] public int MaxLinesCount { get; private set; }
        [field: SerializeField] public float DialogueDisplayInterval { get; private set; }
        
        public List<DialogueData> Dialogues { get; set; }
        public List<AvatarData> Avatars { get; set; }
    }
}