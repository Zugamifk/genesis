using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTextureDrawer : ITextureDrawer
{
    public int Width { get; set; }
    public int Height { get; set; }

    public void Build()
    {

    }

    public Color32 GetPixel(int x, int y)
    {
        if (x==0 || x == Width-1 ||
            y==0 || y == Height-1)
        {
            return Color.white;
        } else
        {
            return new Color32(227, 68, 25, 255);
        }
    }
}
