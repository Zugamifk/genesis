using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITextureDrawer
{
    int Width { get; set; }
    int Height { get; set; }

    void Build();
    Color32 GetPixel(int x, int y);
}
