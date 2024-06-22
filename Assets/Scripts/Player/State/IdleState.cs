using UnityEngine;

public class IdleState : BaseState<PlayerStateMachine.PlayerState>
{
    private PlayerMovement _player;
    public IdleState(PlayerStateMachine.PlayerState stateMachine, PlayerMovement player) : base(stateMachine)
    {
        _player = player;
    }

    public override void Enter()
    {
        Debug.Log("Entering Idle State");
        _player.Anim.Play("Idle_Down");
        HandleFacingDir();
    }

    public override void Update()
    {
        Debug.Log("Updating Idle State");
        if (Mathf.Abs(_player.PlayerRb.velocity.x) > 0.1f
        || Mathf.Abs(_player.PlayerRb.velocity.y) > 0.1f
        && !_player.PlayerStateMachine.IsTransitioningState)
        {
            _player.PlayerStateMachine.TransitionTo(PlayerStateMachine.PlayerState.Walk);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
    }

    private void HandleFacingDir()
    {
        Vector2 lastFacing = _player.LastFacingDir;

        if (lastFacing == Vector2.up)
        {
            _player.Anim.Play("Idle_Up");
        }
        else if (lastFacing == Vector2.down)
        {
            _player.Anim.Play("Idle_Down");
        }
        else
        {
            _player.Anim.Play("Idle");
        }
    }
}