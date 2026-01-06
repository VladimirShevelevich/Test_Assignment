using App.PhoenixFlame.UI;
using UnityEngine;

namespace App.PhoenixFlame
{
    [CreateAssetMenu(fileName = "PhoenixFlameContent", menuName = "Content/PhoenixFlame")]
    public class PhoenixFlameContent : ScriptableObject
    {
        [field: SerializeField] public FlameView FlamePrefab { get; private set; }
        [field: SerializeField] public UiView UiView { get; private set; }
    }
}