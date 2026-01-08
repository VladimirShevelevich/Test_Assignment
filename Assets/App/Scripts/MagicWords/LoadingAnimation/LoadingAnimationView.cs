using DG.Tweening;
using UnityEngine;

public class LoadingAnimationView : MonoBehaviour
{
    void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        transform
            .DORotate(new Vector3(0, 0, -360), 3f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear)
            .SetLink(gameObject);
    }
}
