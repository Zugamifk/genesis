using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rule
{
    public char Predecessor;
    public string Successor;
}

public class LSystem
{
    public HashSet<char> Alphabet = new HashSet<char>();
    public string Start;
    public Dictionary<char, Rule> Productions = new Dictionary<char, Rule>();

    public List<char> Process(List<char> input)
    {
        var output = new List<char>();
        for(int i=0;i<input.Count;i++)
        {
            Rule rule;
            if (Productions.TryGetValue(input[i], out rule))
            {
                output.AddRange(rule.Successor);
            } else
            {
                output.Add(input[i]);
            }
        }

        return output;
    }
}
