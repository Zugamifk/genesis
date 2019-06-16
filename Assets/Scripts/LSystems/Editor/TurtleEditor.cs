using UnityEditor;
using UnityEngine;

//[CustomPropertyDrawer(typeof(Rule))]
//public class RuleDraw: PropertyDrawer
//{
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        EditorGUI.BeginProperty(position, label, property);

//        var predWidth = 75;
//        var predRect = new Rect(position.x, position.y, predWidth, position.height);
//        var succRect = new Rect(predWidth, position.y, position.width - predWidth, position.height);

//        EditorGUI.PropertyField(predRect, property.FindPropertyRelative("Predecessor"));
//        EditorGUI.PropertyField(succRect, property.FindPropertyRelative("Successor"));

//        EditorGUI.EndProperty();
//    }
//}

public class TurtleEditor : EditorWindow
{

    [MenuItem("Hi/Turtle")]
    public static void Open()
    {
        GetWindow<TurtleEditor>();
    }

    void MakeTurtle()
    {
        turtle = new DynamicTurtle();
        derivationStep = 0;
        gen = new TextureGenerator();
        LoadData(data);
    }

    TurtleData data;
    TextureGenerator gen;
    DynamicTurtle turtle;
    string derivation;
    int derivationStep = 0;

    private void OnGUI()
    {
        if (turtle == null)
        {
            MakeTurtle();
        }

        GUI.enabled = false;
        EditorGUILayout.TextField("Current Derivation", derivation);
        EditorGUILayout.IntField("Derivation Step", derivationStep);
        GUI.enabled = true;

        var nt = (TurtleData)EditorGUILayout.ObjectField(data, typeof(TurtleData), false);
        if (nt != data)
        {
            data = nt;
            LoadData(nt);
        }

        if (GUILayout.Button("Step"))
        {
            var cd = turtle.LSystem.Process(turtle.CurrentDerivation);
            turtle.CurrentDerivation = cd;
            derivation = new string(turtle.CurrentDerivation.ToArray());
            derivationStep++;
        }

        if (GUILayout.Button("Generate"))
        {
            var tex = gen.GetTexture(turtle).EncodeToJPG();
            System.IO.File.WriteAllBytes("Assets/turtle.jpg", tex);
        }

        if (GUILayout.Button("Reset"))
        {
            LoadData(data);
            derivation = turtle.LSystem.Start;
            derivationStep = 0;
        }
    }

    void LoadData(TurtleData nt)
    {
        data = nt;
        if (data != null)
        {
            var ls = turtle.LSystem;
            ls.Start = nt.start;
            ls.Productions.Clear();
            foreach (var r in nt.rules)
            {
                ls.Productions.Add(r.Predecessor, r);
            }
            turtle.Reset();
        }
    }
}

