using System.Text.RegularExpressions;

namespace App.MagicWords
{
    public class EmojiConverter
    {
        private readonly EmojisMap _emojisMap;

        public EmojiConverter(MagicWordsContent magicWordsContent)
        {
            _emojisMap = magicWordsContent.EmojisMap;
        }

        public string ReplaceKeysWithEmojis(string text)
        {
            var result = Regex.Replace(text,
                @"\{(.*?)\}",
                m =>
                {
                    var key = m.Groups[1].Value;
                    var unicode = _emojisMap.GetEmojiByKey(key);
                    return unicode ?? "";
                }
            );
            return result;
        }
    }
}