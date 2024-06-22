using UnityEngine;

public class AnimalProduceState : BaseState<AnimalStateMachine.AnimalState>
{
    private AnimalMovement _animal;
    private float timeCounter;
    public AnimalProduceState(AnimalMovement animal, AnimalStateMachine.AnimalState key) : base(key)
    {
        _animal = animal;
    }

    public override void Enter()
    {
        Debug.Log("Enter produce state");
        _animal.Animator.Play("Produce");
        _animal.AnimalRb.velocity = Vector2.zero;
        timeCounter = _animal.ProduceTime;
    }

    public override void Exit()
    {
        Debug.Log("Exit produce state");
        _animal.ProduceProduct();
    }

    public override void Update()
    {
        Debug.Log("Update produce state");
        timeCounter -= Time.deltaTime;
        if (timeCounter <= 0)
        {
            _animal.AnimalStateMachine.TransitionTo(AnimalStateMachine.AnimalState.Idle);
        }
    }
}
