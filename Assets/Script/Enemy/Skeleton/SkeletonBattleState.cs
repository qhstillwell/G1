using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform player;
    private Enemy_Skeleton enemy;
    private int moveDir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _statMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _statMachine, _animBoolName)
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
        if(enemy.IsPLayerDetected())
        {
            stateTimer = enemy.battleTime;
            if(enemy.IsPLayerDetected().distance < enemy.attackDistance)
            {
                if(CanAttack())
               stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if(stateTimer <0|| Vector2.Distance(player.position, enemy.transform.position) > 15)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }



        if(player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }
        enemy.SetVelocity(enemy.moveSpeed * moveDir,enemy.rb.linearVelocity.y);
    }

     private bool CanAttack()
    {
        if(Time.time >= enemy.lastTimeAttacked+enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
}
