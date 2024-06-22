using UnityEngine;

public class WalkState : BaseState<PlayerStateMachine.PlayerState>
{
    private PlayerMovement _player;
    public WalkState(PlayerStateMachine.PlayerState key, PlayerMovement player) : base(key)
    {
        _player = player;
    }

    public override void Enter()
    {
        Debug.Log("Entering Walk State");
        HandleMoveDir();
    }

    public override void Exit()
    {
        Debug.Log("Exiting Walk State");
    }

    public override void Update()
    {
        HandleMoveDir();
        Debug.Log("Updating Walk State");
        if (Mathf.Abs(_player.PlayerRb.velocity.x) < 0.1f
        && Mathf.Abs(_player.PlayerRb.velocity.y) < 0.1f
        && !_player.PlayerStateMachine.IsTransitioningState)
        {
            _player.PlayerStateMachine.TransitionTo(PlayerStateMachine.PlayerState.Idle);
        }
    }

    private void HandleMoveDir()
    {
        if (_player.MoveDir.y > 0)
        {
            Debug.Log("Moving Up");
            // Additional logic for moving up
            _player.Anim.Play("Walk_Up");
        }
        else if (_player.MoveDir.y < 0)
        {
            Debug.Log("Moving Down");
            // Additional logic for moving down
            _player.Anim.Play("Walk_Down");
        }
        else if (_player.MoveDir.x != 0)
        {
            _player.Anim.Play("Walk");
        }
    }
}
