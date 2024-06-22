public class PlayerStateMachine : StateMachine<PlayerStateMachine.PlayerState>
{
    private PlayerMovement player;
    public enum PlayerState
    {
        Idle,
        Walk
    }

    private void Awake()
    {
        player = GetComponent<PlayerMovement>();

        States[PlayerState.Idle] = new IdleState(PlayerState.Idle, player);
        States[PlayerState.Walk] = new WalkState(PlayerState.Walk, player);
    }
}
