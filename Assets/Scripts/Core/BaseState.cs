using System;

public abstract class BaseState<EState> where EState : Enum
{
    public BaseState(EState key)
    {
        StateKey = key;
    }
    public EState StateKey { get; private set; }
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
