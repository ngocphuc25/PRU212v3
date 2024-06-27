using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStateMachine PlayerStateMachine => playerStateMachine;
    public Rigidbody2D PlayerRb => playerRb;
    public Animator Anim => anim;
    public Vector2 MoveDir => moveDir;
    public Vector2 LastFacingDir => lastFacingDir;
    public Inventory Inventory => inventory;
    public PlayerMovement Player => player;
    
    private PlayerMovement player;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D playerRb;
    private Animator anim;
    private PlayerStateMachine playerStateMachine;
    [SerializeField] private Inventory inventory;

    [SerializeField] private float speed;
    private Vector2 moveDir;
    private Vector2 lastFacingDir;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
        inventory = new Inventory(21);
    }

    void Start()
    {
        playerStateMachine.Initialize(PlayerStateMachine.PlayerState.Idle);
    }

    void Update()
    {
        RotatePlayer();

        playerStateMachine.Update();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        playerRb.velocity = moveDir * speed;
    }

    private void RotatePlayer()
    {
        if (moveDir.x >= 0.1f)
        {
            spriteRenderer.flipX = false;
            lastFacingDir = Vector2.right;
        }
        else if (moveDir.x <= -0.1f)
        {
            spriteRenderer.flipX = true;
            lastFacingDir = Vector2.left;
        }
        else if (moveDir.y >= 0.1f)
        {
            lastFacingDir = Vector2.up;
        }
        else if (moveDir.y <= -0.1f)
        {
            lastFacingDir = Vector2.down;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        moveDir = inputValue.Get<Vector2>().normalized;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            var animal = other.gameObject.GetComponent<AnimalMovement>();
            if (animal.IsCaptured) return;
            GameManager.Instance.ShowQuestion(other.gameObject, "What is 2 + 2?", new string[] { "3", "4", "5", "6" }, "4");
        }
    }
}
