 using UnityEngine;

public class Enemy : Entity
{   
    [SerializeField]  protected LayerMask whatIsPlayer;

    [Header("Stun Info")]
    public float stunDuration;
    public Vector2 stunDirection;
    protected bool canBeStun;
    [SerializeField] protected GameObject counterImage;


    [Header("Move info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Attack info")]
    public float attackDistance;
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;


    public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();

    }

    public virtual void OpenCounterAttackWindow()
    {
        canBeStun = true;
        counterImage.SetActive(true);
    }

    public virtual void CloseCounterAttackWindow()
    {
        canBeStun = false;
        counterImage.SetActive(false);
    }

    public virtual bool CanbeStun()
    {
        if (canBeStun)
        {
            CloseCounterAttackWindow();
            return true;
        }
        return false;
    }

    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public virtual RaycastHit2D IsPLayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50 , whatIsPlayer);


    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos(); 
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y));
    }
}
