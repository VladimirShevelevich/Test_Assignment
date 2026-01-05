using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.MagicWords
{
    public class DialogueDataLoader
    {
        public List<Dialogue> Dialogues { get; private set; }
        
        private readonly WordsDataLoader _wordsDataLoader;

        public DialogueDataLoader(WordsDataLoader wordsDataLoader)
        {
            _wordsDataLoader = wordsDataLoader;
        }

        public void Initialize()
        {
            InitDialoguesData();
        }

        private void InitDialoguesData()
        {
            Dialogues = _wordsDataLoader.Data.dialogue.ToList();
            Debug.Log("Dialogues data has been loaded");
        }
    }
}