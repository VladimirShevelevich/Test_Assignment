using System.Collections.Generic;
using UnityEngine;

namespace App.MagicWords
{
    [CreateAssetMenu(fileName = "EmojisMap", menuName = "Content/EmojisMap")]
    public class EmojisMap : ScriptableObject
    {
       
        private readonly Dictionary<string, string> _datas = new()
        {
            {"satisfied", "\ud83d\ude0c"},
            {"intrigued", "\ud83e\udd14"},
            {"neutral", "\ud83d\ude10"},
            {"affirmative", "\ud83d\udc4d"},
            {"laughing", "\ud83d\ude06"},
            {"win", "\ud83c\udfc6"},
        };

        public string GetEmojiByKey(string key)
        {
            if (_datas.TryGetValue(key, out var emoji))
            {
                return emoji;
            }
            
            Debug.LogError($"The emojis map doesn't contain [{key}] emoji data");
            return null;
        }
    }
}