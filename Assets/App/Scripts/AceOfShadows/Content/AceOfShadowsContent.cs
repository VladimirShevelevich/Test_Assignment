using UnityEngine;
using VContainer;

namespace App.AceOfShadows
{
    [CreateAssetMenu(fileName = "AceOfShadowsContent", menuName = "Content/AceOfShadows/AceOfShadowsContent")]
    public class AceOfShadowsContent : ScriptableObject
    {
        [SerializeField] public UiContent _uiContent;
        [SerializeField] public MovementContent _movementContent;
        [SerializeField] public DecksContent _decksContent;

        public void Register(IContainerBuilder builder)
        {
            builder.RegisterInstance(_uiContent);
            builder.RegisterInstance(_movementContent);
            builder.RegisterInstance(_decksContent);

        }
    }
}