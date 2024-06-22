using System.Collections;
using UnityEngine;

public class AnimalMovement : MonoBehaviour, IProduce
{
    public AnimalStateMachine AnimalStateMachine => animalStateMachine;
    public Rigidbody2D AnimalRb => animalRb;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Animator Animator => anim;
    public Transform BasePoint => basePoint;
    public float Radius => radius;
    public float Speed => speed;
    public float TimeProduce => timeToProduce;
    public float ProduceTime => produceTime;
    public float MoveTime => moveTime;
    public bool IsCaptured => isCaptured;

    [SerializeField] private Transform basePoint;
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    [SerializeField] private float moveTime;
    [SerializeField] public float timeToProduce;
    [SerializeField] private float produceTime;
    [SerializeField] private float timer;
    [SerializeField] private bool isCaptured;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D animalRb;
    private AnimalStateMachine animalStateMachine;
    private Animator anim;

    void Awake()
    {
        animalRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        animalStateMachine = GetComponent<AnimalStateMachine>();
    }

    void Start()
    {
        animalStateMachine.Initialize(AnimalStateMachine.AnimalState.Idle);
    }

    void Update()
    {
        if (!isCaptured) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeToProduce;
            animalStateMachine.TransitionTo(AnimalStateMachine.AnimalState.Produce);
        }
        // animalStateMachine.Update();

    }

    void FixedUpdate()
    {
        animalStateMachine.Update();
    }

    public IItem ProduceProduct()
    {
        var item = ProductPool.Instance.SpawnFromPool("Milk", transform.position, Quaternion.identity);
        return item.GetComponent<Milk>();
    }

    public void SetBasePoint(Transform spawnPoint)
    {
        basePoint = spawnPoint;
    }

    public void CaptureAnimal()
    {
        isCaptured = true;
        AnimalPool.Instance.RemoveAnimalFromPool(gameObject, basePoint);
        FarmManager.Instance.AddAnimalToFarm(gameObject);
    }

    private void OnDrawGizmos()
    {
        if (basePoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(basePoint.position, radius);
        }
    }
}
