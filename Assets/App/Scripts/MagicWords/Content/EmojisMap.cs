using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.MagicWords
{
    

    [CreateAssetMenu(fileName = "EmojisMap", menuName = "Content/EmojisMap")]
    public class EmojisMap : ScriptableObject
    {
        [Serializable]
        public class EmojiData
        {
            public string Key;
            public string Emoji;
        }

        [SerializeField] private List<EmojiData> _datas;

        public string GetEmojiByKey(string key)
        {
            var data = _datas.FirstOrDefault(x => x.Key == key);
            if (data != null) 
                return data.Emoji;
            
            Debug.LogError($"The emojis map doesn't contain [{key}] emoji data");
            return null;
        }
    }
}