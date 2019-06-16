using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using U = UnityEngine.Tilemaps;
public class MapViewController : MonoBehaviour
{
    [SerializeField]
    U.Tile m_TestTile;

    const int k_TileMapSize = 10;
    U.Tilemap m_TileMap;
    private void Awake()
    {
        m_TileMap = GetComponentInChildren<U.Tilemap>();
        m_TileMap.size = new Vector3Int(k_TileMapSize, k_TileMapSize, 0);

        var tg = new DebugTextureDrawer();
        int sz = 32;
        tg.Width = sz;
        tg.Height = sz;
        var tex = ServiceLocator.Get<TextureGenerator>().GetTexture(tg);
        var spr = Sprite.Create(tex, new Rect(0, 0, sz, sz), new Vector2(0.5f, 0.5f), pixelsPerUnit: sz);
        m_TestTile.sprite = spr;
        for (int x = -k_TileMapSize; x < k_TileMapSize; x++)
        {
            for (int y = -k_TileMapSize; y < k_TileMapSize; y++)
            {
                var pos = new Vector3Int(x, y, 0);
                m_TileMap.SetTile(pos, m_TestTile);
                m_TileMap.SetTileFlags(pos, U.TileFlags.None);
                m_TileMap.SetColor(pos, Color.white *0/*Mathf.PerlinNoise(x*25f, y*0.05f)*/);
            }
        }
        m_TileMap.RefreshAllTiles();
    }
}
