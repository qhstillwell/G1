using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindow = 2;


    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        HorizontalMove = 0; //fix bug attack direction
        if (comboCounter > 2 || Time.time >= lastTimeAttacked+comboWindow)
        {
            comboCounter = 0; 
        }

        player.anim.SetInteger("ComboCounter", comboCounter);

        #region Choose attack direction

        float attackDir = player.facingDir;

        if ( HorizontalMove != 0)
        {
            attackDir = HorizontalMove; 
        }
        #endregion

        player.SetVelocity(player.attackMovement[comboCounter] * attackDir, player.rb.linearVelocity.y);

        stateTimer = .1f;
    }

    public override void Exit()
    {

        base.Exit();

        player.StartCoroutine("BusyFor", .15f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer <0)
        {
            player.ZeroVelocity();
        }

        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }
}
