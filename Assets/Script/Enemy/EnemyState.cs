using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;

    protected bool triggerCalled;
    private string animBoolName;

    protected float stateTimer;
    public EnemyState(Enemy _enemyBase, EnemyStateMachine _statMachine, string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _statMachine;
          this.animBoolName = _animBoolName;
    }


    public virtual void Enter()
    {
         triggerCalled = false;
        enemyBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
