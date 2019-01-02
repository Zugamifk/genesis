using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureDrawer
{
    public int Width { get; set; }
    public int Height { get; set; }

    public virtual Color32 GetPixel(int x, int y)
    {
        return Color.white;
    }
}
