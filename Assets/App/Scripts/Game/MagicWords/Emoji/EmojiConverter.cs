using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace App.MagicWords
{
    public static class EmojiConverter
    {
        private static readonly Dictionary<string, string> _datas = new()
        {
            {"satisfied", "\ud83d\ude0c"},
            {"intrigued", "\ud83e\udd14"},
            {"neutral", "\ud83d\ude10"},
            {"affirmative", "\ud83d\udc4d"},
            {"laughing", "\ud83d\ude06"},
            {"win", "\ud83c\udfc6"},
        };

        public static string ReplaceKeysWithEmojis(string text)
        {
            var result = Regex.Replace(text,
                @"\{(.*?)\}",
                m =>
                {
                    var key = m.Groups[1].Value;
                    var unicode = GetEmojiByKey(key);
                    return unicode ?? "";
                }
            );
            return result;
        }

        private static string GetEmojiByKey(string key)
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