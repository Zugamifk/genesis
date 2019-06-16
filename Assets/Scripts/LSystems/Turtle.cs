using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : ITextureDrawer
{
    struct State
    {
        public Vector2Int pos;
        public Vector2Int dir;
    }
    const char kStep = 'f';
    const char kStepAndDraw = 'F';
    const char kTurnLeft = '+';
    const char kTurnRight = '-';
    const char kPush = '[';
    const char kPop = ']';

    const int kSize = 256;
    public int Width { get; set; }
    public int Height { get; set; }

    Vector2Int Start;
    public LSystem LSystem = new LSystem();
    public List<char> CurrentDerivation = new List<char>();
    protected Dictionary<Vector2Int, bool> DrawnTiles = new Dictionary<Vector2Int, bool>();

    public Turtle()
    {
        Width = kSize;
        Height = kSize;
        LSystem.Alphabet.Add(kStep);
        LSystem.Alphabet.Add(kStepAndDraw);
        LSystem.Alphabet.Add(kTurnLeft);
        LSystem.Alphabet.Add(kTurnRight);
        Start = new Vector2Int(kSize / 2, kSize / 2);
    }

    public void Reset()
    {
        CurrentDerivation.Clear();
        if (LSystem.Start != null)
        {
            CurrentDerivation.AddRange(LSystem.Start);
        }
        DrawnTiles.Clear();
    }

    public virtual void Build()
    {
        var pos = Start;
        var dir = Vector2Int.up;
        DrawnTiles.Clear();
        Stack<State> stack = new Stack<State>();
        for(int i=0;i<CurrentDerivation.Count;i++)
        {
            switch (CurrentDerivation[i])
            {
                case kStep: pos += dir; break;
                case kStepAndDraw:
                    {
                        DrawnTiles[pos] = true;
                        pos += dir;
                    }
                    break;
                case kTurnLeft: dir = TurnLeft(dir); break;
                case kTurnRight: dir = TurnRight(dir); break;
                case kPush:
                    {
                        stack.Push(new State()
                        {
                            pos = pos,
                            dir = dir
                        });
                    }
                    break;
                case kPop:
                    {
                        var s = stack.Pop();
                        pos = s.pos;
                        dir = s.dir;
                    }
                    break;
                default: break;
            }
        }
    }

    public virtual Color32 GetPixel(int x, int y)
    {
        if(DrawnTiles.ContainsKey(new Vector2Int(x,y)))
        {
            return Color.white;
        } else
        {
            return Color.black;
        }
    }

    Vector2Int TurnLeft(Vector2Int dir)
    {
        return new Vector2Int(-dir.y, dir.x );
    }

    Vector2Int TurnRight(Vector2Int dir)
    {
        return new Vector2Int(dir.y, -dir.x);
    }
}
