using DG.Tweening;
using UnityEngine;

public class MessageView : MonoBehaviour
{
    void Start()
    {
        ShowAnimation();
    }

    private void ShowAnimation()
    {
        transform.localScale = Vector3.zero;;
        transform.DOScale(1, 0.1f).SetLink(gameObject);
    }
}
