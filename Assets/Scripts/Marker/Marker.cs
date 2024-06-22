using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    CharacterController characterController;
    Rigidbody2D rigidbody2D;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractaleArea = 1.2f;
    [SerializeField] TilemapMarkerController tilemapMarkerController;
    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (markerManager != null && tilemapMarkerController != null)
        {
            Marker1();
        }
        else
        {
            Debug.LogWarning("MarkerManager or TilemapMarkerController is not assigned.");
        }
    }

    private void Marker1()
    {
        Vector3Int gridPosition = tilemapMarkerController.GetGridPosition(Input.mousePosition, true);
        markerManager.markedCellPossition = gridPosition;
    }
}
