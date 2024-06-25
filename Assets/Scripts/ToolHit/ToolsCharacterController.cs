using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ToolHitCharacterController : MonoBehaviour
{   
    CharacterMovement character2;


    Rigidbody2D rigidbod;
    [SerializeField] float offsetDistance= 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    private void Awake() {
        character2 =GetComponent<CharacterMovement>();
        rigidbod =GetComponent<Rigidbody2D>();
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            UseTool();
        }
    }
    
    private void UseTool(){
      Vector2 position = rigidbod.position + character2.lastMotionVector *offsetDistance ;
      Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
     foreach(Collider2D c in colliders)
     {
        ToolHit hit = c.GetComponent<ToolHit>();
        if(hit != null)
        {
            hit.Hit();
            break;
        }
     }
    }
}
