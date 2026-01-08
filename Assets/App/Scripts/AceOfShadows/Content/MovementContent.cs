using UnityEngine;

namespace App.AceOfShadows
{
    [CreateAssetMenu(fileName = "MovementContent", menuName = "Content/AceOfShadows/Movement")]
    public class MovementContent : ScriptableObject
    {
        [field: SerializeField] public float MoveDuration { get; private set; }
        [field: SerializeField] public float MoveTimeInterval { get; private set; }
    }
}