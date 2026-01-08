using TMPro;
using UnityEngine;

namespace App.FPS
{
    public class FpsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counter;

        private float timer;
        
        private void Update()
        {
            timer += Time.unscaledDeltaTime;

            if (timer >= 0.25f)
            {
                UpdateFps();
                timer = 0f;
            }
        }

        private void UpdateFps()
        {
            _counter.text = $"{(int)(1f / Time.unscaledDeltaTime)}";
        }
    }
}