using System;
using Newtonsoft.Json;

namespace App.MagicWords
{
    public class DataParser
    {
        public WordsData Parse(string json)
        {
            var data = JsonConvert.DeserializeObject<WordsData>(json);
            if (data == null)
                throw new Exception("Words data parsing failed");

            return data;
        }
    }
}