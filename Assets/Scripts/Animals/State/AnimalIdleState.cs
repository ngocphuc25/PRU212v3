using UnityEngine;

public class AnimalIdleState : BaseState<AnimalStateMachine.AnimalState>
{
    private AnimalMovement _animal;
    private float timeDelay = 2.5f;
    private float timeCounter = 0f;
    public AnimalIdleState(AnimalMovement animal, AnimalStateMachine.AnimalState key) : base(key)
    {
        _animal = animal;
    }

    public override void Enter()
    {
        Debug.Log("Enter idle state");
        //Play idle animation
        _animal.Animator.Play("Idle");
    }

    public override void Exit()
    {
        Debug.Log("Exit idle state");

        //Reset time counter
        timeCounter = 0;
    }

    public override void Update()
    {
        Debug.Log("Update idle state");

        timeCounter += Time.deltaTime;
        if (timeCounter >= timeDelay)
        {
            _animal.AnimalStateMachine.TransitionTo(AnimalStateMachine.AnimalState.Walk);
        }
    }
}
