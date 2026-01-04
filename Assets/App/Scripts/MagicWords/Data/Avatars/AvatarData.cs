using App.MagicWords;
using UnityEngine;

namespace App.Scripts.MagicWords
{
    public class AvatarData
    {
        public string Name { get; private set; }
        public Texture2D Texture { get; private set; }
        public AvatarPosition Position { get; private set; }

        public AvatarData(string name, Texture2D texture, AvatarPosition position)
        {
            Name = name;
            Texture = texture;
            Position = position;
        }
    }
}