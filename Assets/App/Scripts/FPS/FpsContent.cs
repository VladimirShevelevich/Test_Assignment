using UnityEngine;

namespace App.FPS
{
    [CreateAssetMenu(fileName = "FpsContent", menuName = "Content/FPS")]
    public class FpsContent : ScriptableObject
    {
        [field: SerializeField] public FpsView FpsPrefab { get; private set; } 
    }
}