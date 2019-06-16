using UnityEngine;

public class DynamicTurtle : Turtle
{
    const int kDangerMax = 1 << 20;

    Vector2Int offset;
    public override void Build()
    {
        base.Build();

        int minx, miny, maxx, maxy;
        minx = miny = int.MaxValue;
        maxx = maxy = int.MinValue;

        foreach (var pos in DrawnTiles.Keys)
        {
            minx = Mathf.Min(minx, pos.x);
            maxx = Mathf.Max(maxx, pos.x);
            miny = Mathf.Min(miny, pos.y);
            maxy = Mathf.Max(maxy, pos.y);
        }

        offset = new Vector2Int(minx, miny);
        Width = maxx - minx;
        Height = maxy - miny;
        
        if(Width*Height > kDangerMax)
        {
            Debug.LogWarning("WARNING: large texture");
        }
    }

    public override Color32 GetPixel(int x, int y)
    {
        x += offset.x;
        y += offset.y;
        return base.GetPixel(x, y);
    }
}
