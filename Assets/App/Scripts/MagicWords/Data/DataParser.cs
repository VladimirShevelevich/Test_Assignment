using System;
using Newtonsoft.Json;

namespace App.MagicWords
{
    public static class DataParser
    {
        public static T Parse<T>(string json) where T : class
        {
            var data = JsonConvert.DeserializeObject<T>(json);
            if (data == null || data == default)
                throw new Exception("Data parsing failed");

            return data;
        }
    }
}