using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> CurrentState;

    public bool IsTransitioningState = false;

    public event Action<BaseState<EState>> StateChanged;

    public void Initialize(EState key)
    {
        CurrentState = States[key];
        CurrentState.Enter();

        StateChanged?.Invoke(CurrentState);
    }

    public void TransitionTo(EState key)
    {
        if (IsTransitioningState)
            return;

        IsTransitioningState = true;
        StartCoroutine(Transition(key));
        // CurrentState.Exit();
        // CurrentState = States[key];
        // CurrentState.Enter();
        // IsTransitioningState = false;

        // StateChanged?.Invoke(CurrentState);
    }

    private IEnumerator Transition(EState key)
    {
        CurrentState.Exit();
        yield return new WaitForEndOfFrame(); // Delay for one frame or customize the delay as needed

        CurrentState = States[key];
        CurrentState.Enter();
        IsTransitioningState = false;

        StateChanged?.Invoke(CurrentState);
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

}
