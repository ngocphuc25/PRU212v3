using UnityEngine;

public class AnimalWalkState : BaseState<AnimalStateMachine.AnimalState>
{
    private AnimalMovement _animal;
    private Vector2 randomPos;
    private bool isFacingRight = true;
    private float currentPos;
    private float timer;
    public AnimalWalkState(AnimalMovement animal, AnimalStateMachine.AnimalState key) : base(key)
    {
        _animal = animal;
    }

    public override void Enter()
    {
        Debug.Log("Enter walk state");
        _animal.Animator.Play("Walk");
        currentPos = _animal.transform.position.x;
        timer = _animal.MoveTime;
        randomPos = GetRandomPositionInCircle();
    }

    public override void Exit()
    {
        Debug.Log("Exit walk state");
    }

    public override void Update()
    {
        Debug.Log("Update walk state");

        timer -= Time.deltaTime;

        CheckIsFacing();
        Flip();

        var isMoved = MovePosition(randomPos);
        if (isMoved)
        {
            _animal.AnimalStateMachine.TransitionTo(AnimalStateMachine.AnimalState.Idle);
        }
    }

    void CheckIsFacing()
    {
        if (currentPos > randomPos.x)
        {
            isFacingRight = false;
        }
        else
        {
            isFacingRight = true;
        }
    }

    void Flip()
    {
        if (!isFacingRight && !_animal.SpriteRenderer.flipX)
        {
            _animal.SpriteRenderer.flipX = true;
        }
        else if (isFacingRight && _animal.SpriteRenderer.flipX)
        {
            _animal.SpriteRenderer.flipX = false;
        }
    }

    public Vector2 GetRandomPositionInCircle()
    {
        return Random.insideUnitCircle * _animal.Radius + (Vector2)_animal.BasePoint.position;
    }

    public bool MovePosition(Vector2 randomPos)
    {
        Vector2 direction = (randomPos - _animal.AnimalRb.position).normalized;

        _animal.AnimalRb.velocity = direction * _animal.Speed;

        if (Vector2.Distance(_animal.AnimalRb.position, randomPos) < 0.1f || timer <= 0)
        {
            _animal.AnimalRb.velocity = Vector2.zero;
            return true;
        }

        return false;
    }
}
