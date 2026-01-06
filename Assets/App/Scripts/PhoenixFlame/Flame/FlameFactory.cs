using UnityEngine;

namespace App.PhoenixFlame
{
    public class FlameFactory
    {
        private readonly PhoenixFlameContent _content;

        public FlameFactory(PhoenixFlameContent content)
        {
            _content = content;
        }

        public FlameView Create()
        {
            return Object.Instantiate(_content.FlamePrefab);
        }
    }
}