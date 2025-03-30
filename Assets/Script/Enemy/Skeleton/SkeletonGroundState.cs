using UnityEngine;

public class SkeletonGroundState : EnemyState
{
    protected Enemy_Skeleton enemy;
    protected Transform player;
    public SkeletonGroundState(Enemy _enemyBase, EnemyStateMachine _statMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _statMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(enemy.IsPLayerDetected()|| Vector2.Distance(enemy.transform.position, player.position) < 2 )
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
