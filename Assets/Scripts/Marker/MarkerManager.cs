using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] Tilemap targetTilemap;
   [SerializeField] TileBase tile;
    bool show;
   public Vector3Int markedCellPossition;
   Vector3Int oldCellPosition;

    private void Update() {
    if (show == false){return ;}
    targetTilemap.SetTile(oldCellPosition,null);
    targetTilemap.SetTile(markedCellPossition,tile);
    oldCellPosition = markedCellPossition;
    }

    internal void Show(bool selectable)
    {
        show =selectable;
        targetTilemap.gameObject.SetActive(show);
    }
}
