using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, player.rb.linearVelocity.y);

    }

    public override void Update()
    {
        base.Update();
        if(!player.IsGroundDetected()&& player.IsWallDetected())
        {
            stateMachine.ChangeState(player.wallSlideStates);
        }


        player.SetVelocity(player.dashSpeed*player.dashDir, 0);

        if (stateTimer < 0)
        
            stateMachine.ChangeState(player.idleState);
        
    }
}
