using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Marker : MonoBehaviour
{
    CharacterController characterController;
    Rigidbody2D rigidbody2D1 ;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractaleArea = 1.2f;
    [SerializeField] TilemapMarkerController tilemapMarkerController;
    [SerializeField] float maxdistance = 1.5f;
    [SerializeField] CropManager cropManager;
    [SerializeField] TileData plowableTiles;
    // Start is called before the first frame update
    Vector3Int selectedTilePosition;
    bool selectable;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rigidbody2D1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        SelectedTile();
        CanSelectCheck();
        Marker1();
        if(Input.GetMouseButtonDown(0)){
            UseToolGrid();
        }

    }

    private void Marker1()
    {
        markerManager.markedCellPossition = selectedTilePosition;
    }
    void  CanSelectCheck(){
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable= Vector2.Distance(characterPosition,cameraPosition)<maxdistance;
        markerManager.Show(selectable);
    }
    private void SelectedTile()
    {
        selectedTilePosition = tilemapMarkerController.GetGridPosition(Input.mousePosition, true);
    }

    private void  UseToolGrid(){
        if (selectable == true)
        {
            TileBase tileBase = tilemapMarkerController.GetTileBase(selectedTilePosition);
            TileData tileData = tilemapMarkerController.GetTileData(tileBase);
            if (tileData != plowableTiles){return;}
            if (cropManager.Check(selectedTilePosition))
            {
                cropManager.Seed(selectedTilePosition);
            }
            else
            {
                 cropManager.Plow(selectedTilePosition);
            }
           
        }
    }
}
