using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// What a word means, a set of expressions
[System.Serializable]
public class Definition
{
    [SerializeField]
    public List<Expression> Meaning = new List<Expression>();
}
