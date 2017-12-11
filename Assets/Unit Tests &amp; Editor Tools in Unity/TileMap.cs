using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {
    // key should be "x,y"
    public Dictionary<string, GameObject> tiles;

    public bool Initialized
    {
        get
        {
            return tiles != null;
        }
    }

    public void Initialize()
    {
        tiles = new Dictionary<string, GameObject>();
    }

    public static string CoordToKey(int x, int y)
    {
        return x + "," + y;
    }

    public void PlaceTile(int x, int y, GameObject tile)
    {
        RemoveTile(x, y);
        string key = CoordToKey(x, y);
        GameObject newTile = Instantiate(tile, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity);
        newTile.transform.parent = transform;
        tiles[key] = newTile;
    }

    public void RemoveTile(int x, int y)
    {
        string key = CoordToKey(x, y);
        if (tiles.ContainsKey(key))
        {
            GameObject.DestroyImmediate(tiles[key]);
            tiles.Remove(key);
        }
    }
}
