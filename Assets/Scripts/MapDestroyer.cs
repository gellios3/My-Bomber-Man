using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;

    [SerializeField] private Tile _wallTile;
    [SerializeField] private Tile _destructibleTile;

    [SerializeField] private GameObject _explosionPrefab;

    /// <summary>
    /// Explode bomb
    /// </summary>
    /// <param name="worldPos"></param>
    /// <param name="radius"></param>
    public void Explode(Vector2 worldPos, int radius)
    {
        var originCell = _tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell);

        for (var i = 1; i < radius + 1; i++)
        {
            if (!ExplodeCell(originCell + new Vector3Int(i, 0, 0)))
                break;
        }

        for (var i = 1; i < radius + 1; i++)
        {
            if (!ExplodeCell(originCell + new Vector3Int(0, i, 0)))
                break;
        }

        for (var i = 1; i < radius + 1; i++)
        {
            if (!ExplodeCell(originCell + new Vector3Int(-i, 0, 0)))
                break;
        }

        for (var i = 1; i < radius + 1; i++)
        {
            if (!ExplodeCell(originCell + new Vector3Int(0, -i, 0)))
                break;
        }
    }

    /// <summary>
    /// Explode cell
    /// </summary>
    /// <param name="cell"></param>
    /// <returns></returns>
    private bool ExplodeCell(Vector3Int cell)
    {
        var tile = _tilemap.GetTile<Tile>(cell);

        if (tile == _wallTile)
        {
            return false;
        }

        if (tile == _destructibleTile)
        {
            _tilemap.SetTile(cell, null);
        }

        var pos = _tilemap.GetCellCenterWorld(cell);
        var explosionEffect = Instantiate(_explosionPrefab, pos, Quaternion.identity);

        // Destroy Effect after 2 seconds 
        Destroy(explosionEffect, 2);

        return true;
    }
}