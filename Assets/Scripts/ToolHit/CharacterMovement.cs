using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector2 lastPosition;
    public Vector2 lastMotionVector { get;  set; }

    void Start()
    {
       
        lastPosition = new Vector2(transform.position.x, transform.position.y);
        lastMotionVector = Vector2.zero;
    }

    void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        lastMotionVector = currentPosition - lastPosition;
        lastPosition = currentPosition;

        
    }
}
