using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    const int k_ChunkSize = 16;

    Dictionary<Vector2Int, Chunk> m_Chunks = new Dictionary<Vector2Int, Chunk>();

    public Tile GetTile(float x, float y)
    {
        var cx = Mathf.FloorToInt(x / (float)k_ChunkSize);
        var cy = Mathf.FloorToInt(y / (float)k_ChunkSize);
        Chunk c;
        var pos = new Vector2Int(cx, cy);
        if (!m_Chunks.TryGetValue(pos, out c))
        {
            c = new Chunk(k_ChunkSize, k_ChunkSize);
            m_Chunks[pos] = c;
        }

        var tx = Mathf.FloorToInt(x % k_ChunkSize);
        var ty = Mathf.FloorToInt(y % k_ChunkSize);
        return c[tx, ty];
    }
}
