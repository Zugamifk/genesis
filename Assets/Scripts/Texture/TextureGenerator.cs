using UnityEngine;

public class TextureGenerator
{
    public TextureGenerator()
    {
        ServiceLocator.Register(this);
    }

    public Texture2D GetTexture(TextureDrawer drawer)
    {
        var tex = new Texture2D(drawer.Width, drawer.Height, TextureFormat.ARGB32, false);
        var data = tex.GetRawTextureData<Color32>();
        int index = 0;
        for (int y = 0; y < drawer.Height; y++)
        {
            for (int x = 0; x < drawer.Width; x++)
            {
                data[index++] = drawer.GetPixel(x, y);
            }
        }
        tex.Apply();
        return tex;
    }
}
