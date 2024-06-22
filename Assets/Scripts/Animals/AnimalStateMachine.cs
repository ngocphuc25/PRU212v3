using UnityEngine;

public class AnimalStateMachine : StateMachine<AnimalStateMachine.AnimalState>
{
    private AnimalMovement animal;
    public enum AnimalState
    {
        Idle,
        Walk,
        Produce
    }

    private void Awake()
    {
        animal = GetComponent<AnimalMovement>();

        States[AnimalState.Idle] = new AnimalIdleState(animal, AnimalState.Idle);
        States[AnimalState.Walk] = new AnimalWalkState(animal, AnimalState.Walk);
        States[AnimalState.Produce] = new AnimalProduceState(animal, AnimalState.Produce);
    }
}
