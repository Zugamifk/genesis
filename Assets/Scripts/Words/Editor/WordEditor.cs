using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class WordEditor : EditorWindow
{
    const string k_GlossariesPath = "Glossaries";

    class WordState
    {
        public Word Word;
        public bool IsVisible;
    }

    [MenuItem("Hi/Words")]
    public static void Open()
    {
        GetWindow<WordEditor>();
    }

    Dictionary<string, WordState> m_Lookup = new Dictionary<string, WordState>();

    Glossary m_Glossary;
    string m_Filter;
    Vector2 m_WordScroll;
    List<string> m_FilteredWords = new List<string>();

    void OnEnable()
    {
        LoadGlossary(m_Glossary);
    }

    private void OnGUI()
    {
        var newGlossary = (Glossary)EditorGUILayout.ObjectField("Glossary", m_Glossary, typeof(Glossary), false);
        if(newGlossary!=m_Glossary)
        {
            LoadGlossary(newGlossary);
        }

        var newFilter = GUILayout.TextField(m_Filter);
        if(m_Filter!=newFilter)
        {
            m_Filter = newFilter;
            FilterWords();
        }
        if (!string.IsNullOrEmpty(m_Filter) && m_FilteredWords.Count == 0 && GUILayout.Button("New Word"))
        {
            var word = new Word()
            {
                Name = m_Filter
            };
            m_Lookup.Add(m_Filter, new WordState() { Word = word, IsVisible = true });
            m_Glossary.Words.Add(word);
            FilterWords();
        }

        m_WordScroll = GUILayout.BeginScrollView(m_WordScroll);
        bool modified = false;
        foreach(var word in m_FilteredWords)
        {
            modified |= DrawWord(m_Lookup[word]);
        }
        if (modified) FilterWords();
        GUILayout.EndScrollView();

        using (new GUILayout.HorizontalScope())
        {
            GUILayout.Label($"{m_FilteredWords.Count}/{m_Lookup.Count} words");
            if(GUILayout.Button("Reload"))
            {
                OnEnable();
            }
        }
    }

    bool DrawWord(WordState word)
    {
        word.IsVisible = EditorGUILayout.Foldout(word.IsVisible, word.Word.Name);
        if(word.IsVisible)
        {
            EditorGUI.indentLevel++;
            var w = word.Word;
            var newName = GUILayout.TextField(w.Name);
            if (newName != w.Name)
            {
                m_Lookup.Remove(w.Name);
                m_Lookup.Add(newName, word);
                w.Name = newName;
                return true;
            }
            Expression delete=null;
            foreach(var ex in w.Definition.Meaning)
            {
                if(DrawExpression(ex))
                {
                    delete = ex;
                }
            }
            if(delete!=null)
            {
                w.Definition.Meaning.Remove(delete);
            }
            if(GUILayout.Button("Add Expression"))
            {
                w.Definition.Meaning.Add(new Expression());
            }
            EditorGUI.indentLevel--;
        }

        return false;
    }

    bool DrawExpression(Expression ex)
    {
        using(new GUILayout.HorizontalScope())
        {
            ex.Quantifier = (Quantifier)EditorGUILayout.EnumPopup(ex.Quantifier, GUILayout.Width(50));
            ex.Word = GUILayout.TextField(ex.Word);
            if (GUILayout.Button("X", GUILayout.Width(25))) return true;
        }
        return false;
    }

    void LoadGlossary(Glossary glossary)
    {
        m_Glossary = glossary;
        m_Lookup.Clear();
        if (glossary != null)
        {
            foreach (var word in glossary.Words)
            {
                var ws = new WordState()
                {
                    Word = word
                };
                m_Lookup.Add(word.Name, ws);
            }
        }
        FilterWords();
        Debug.Log($"Loaded {m_Lookup.Count} words");
    }

    void FilterWords()
    {
        m_FilteredWords.Clear();
        foreach(var word in m_Lookup.Keys)
        {
            if(string.IsNullOrEmpty(m_Filter) || word.StartsWith(m_Filter))
            {
                m_FilteredWords.Add(word);
            }
        }
    }
}
