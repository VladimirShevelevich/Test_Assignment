using UnityEngine;

namespace App.PhoenixFlame
{
    public class FlameView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void StartAnimation()
        {
            _animator.SetTrigger("start");
        }
    }
}