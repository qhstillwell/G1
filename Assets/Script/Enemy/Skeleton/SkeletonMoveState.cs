using UnityEngine;

public class SkeletonMoveState : SkeletonGroundState
{
    public SkeletonMoveState(Enemy _enemyBase, EnemyStateMachine _statMachine, string _animBoolName, Enemy_Skeleton enemy) : base(_enemyBase, _statMachine, _animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity( enemy.moveSpeed * enemy.facingDir,  enemy.rb.linearVelocity.y);

        if(enemy.IsWallDetected() || !enemy.IsGroundDetected() )
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
