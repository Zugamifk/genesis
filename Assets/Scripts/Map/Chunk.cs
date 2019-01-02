using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    Tile[,] m_Tiles;

    public Tile this[int x, int y]
    {
        get => m_Tiles[x, y];
        set => m_Tiles[x, y] = value;
    }

    public Chunk(int width, int height)
    {
        m_Tiles = new Tile[width, height];
    }
}
