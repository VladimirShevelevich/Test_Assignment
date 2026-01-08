using DG.Tweening;
using UnityEngine;

namespace App.AceOfShadows
{
    public class MessageView : MonoBehaviour
    {
        void Start()
        {
            ShowStartAnimation();
        }

        private void ShowStartAnimation()
        {
            transform.localScale = Vector3.zero;;
            transform.DOScale(1, 0.1f).SetLink(gameObject);
        }
    }
}
