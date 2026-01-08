using UnityEngine;

namespace App.AceOfShadows
{
    [CreateAssetMenu(fileName = "UiContent", menuName = "Content/AceOfShadows/UI")]
    public class UiContent : ScriptableObject
    {
        [field: SerializeField] public GameObject MessagePrefab { get; private set; }
    }
}