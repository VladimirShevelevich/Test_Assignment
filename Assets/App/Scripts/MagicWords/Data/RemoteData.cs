using System;
using System.Collections.Generic;

namespace App.MagicWords
{
    [Serializable]
    public class RemoteData
    {
        public List<DialogueData> dialogue { get; set; }
        public List<Avatar> avatars { get; set; }
    
        public class Avatar
        {
            public string name { get; set; }
            public string url { get; set; }
            public string position { get; set; }
        }
    }   
}