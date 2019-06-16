using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a symbol with a meaning in the world
[System.Serializable]
public class Word
{
    // what is the word?
    public string Name;
    public Definition Definition = new Definition();
}
