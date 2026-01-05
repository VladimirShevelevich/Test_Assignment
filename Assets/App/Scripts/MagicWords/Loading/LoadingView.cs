using DG.Tweening;
using UnityEngine;

public class LoadingView : MonoBehaviour
{
    void Start()
    {
        transform
            .DORotate(new Vector3(0, 0, -360), 3f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear)
            .SetLink(gameObject);
    }
}
