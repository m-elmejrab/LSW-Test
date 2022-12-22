using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public List<Sentence> dialogSentences;

    [Serializable]
    public class Sentence
    {
        public string speakerName;
        public string textToSay;
        public string soundName;
    }
}
