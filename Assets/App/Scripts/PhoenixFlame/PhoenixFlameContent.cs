using UnityEngine;

namespace App.PhoenixFlame
{
    [CreateAssetMenu(fileName = "PhoenixFlameContent", menuName = "Content/PhoenixFlame")]
    public class PhoenixFlameContent : ScriptableObject
    {
        [field: SerializeField] public FlameView FlamePrefab { get; private set; }
    }
}