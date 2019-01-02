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

        var tg = new TextureDrawer();
        tg.Width = 16;
        tg.Height = 16;
        var tex = ServiceLocator.Get<TextureGenerator>().GetTexture(tg);
        m_TestTile.sprite = Sprite.Create(tex, new Rect(0, 0, 16, 16), new Vector2(0.5f, 0.5f));

        for (int x = -k_TileMapSize; x < k_TileMapSize; x++)
        {
            for (int y = -k_TileMapSize; y < k_TileMapSize; y++)
            {
                m_TileMap.SetTile(new Vector3Int(x, y, 0), m_TestTile);
            }
        }
        m_TileMap.RefreshAllTiles();
    }
}
