using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] Tilemap targetTilemap;
   [SerializeField] TileBase tile;

   public Vector3Int markedCellPossition;
   Vector3Int oldCellPosition;

    private void Update() {
    targetTilemap.SetTile(oldCellPosition,null);
    targetTilemap.SetTile(markedCellPossition,tile);
    oldCellPosition = markedCellPossition;
    }
}
