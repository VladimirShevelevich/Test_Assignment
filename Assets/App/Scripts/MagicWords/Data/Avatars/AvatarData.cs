using App.MagicWords;
using UnityEngine;

namespace App.Scripts.MagicWords
{
    public class AvatarData
    {
        public string Name { get; private set; }
        public Sprite Sprite { get; private set; }
        public AvatarPosition Position { get; private set; }

        public AvatarData(string name, Sprite sprite, AvatarPosition position)
        {
            Name = name;
            Sprite = sprite;
            Position = position;
        }
    }
}