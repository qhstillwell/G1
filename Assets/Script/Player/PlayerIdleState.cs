using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(HorizontalMove==player.facingDir&& player.IsWallDetected())
        {
            return;
        }

        if (HorizontalMove != 0&& !player.isBusy)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
