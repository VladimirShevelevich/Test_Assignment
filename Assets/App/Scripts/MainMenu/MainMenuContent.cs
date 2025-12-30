using UnityEngine;

namespace App.MainMenu
{
    [CreateAssetMenu(fileName = "MainMenuContent", menuName = "Content/MainMenu")]
    public class MainMenuContent : ScriptableObject
    {
        [field: SerializeField] public MainMenuView ViewPrefab { get; private set; }
    }
}