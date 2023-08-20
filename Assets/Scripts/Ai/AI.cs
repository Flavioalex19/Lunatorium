using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public enum AiState
{
    None,
    Pursuit,
    Attack,
    Recover,
    Stun,
    Dead
}

public class AI : MonoBehaviour
{

    public AiState AiState;

    [SerializeField] float _damage;
    bool _dealDamage = false;
    public bool _canAttack = false;

    public float _recoveringTimer = 0;
    public float RecoveringTimerReset;
    bool _isRecovering = false;


    public Transform _target;
    public tg_HitBox _hitBox;

    [SerializeField] AudioSource _source_footsteps;

    public NavMeshAgent _agent;
    EnemyStats _enemyStats;
    //public Animator _animator;
    private void Awake()
    {
        _source_footsteps.Stop();
    }
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemyStats = GetComponent<EnemyStats>();
        //_animator = GetComponent<Animator>();
        _hitBox.SetDamage(_damage);
        _recoveringTimer = RecoveringTimerReset;

        TurnOffColliderHitbox();
        _source_footsteps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyStats.GetHP() < 0) AiState = AiState.Dead;

        switch (AiState)
        {
            case AiState.None:
                _agent.isStopped = true;
                break;
            case AiState.Pursuit:
                Pursuit();
                break;
            case AiState.Attack:
                //call animation
                //_animator.SetBool("Attack", true);
                _canAttack = true;
                //Attack();
                break;
            case AiState.Recover:
                Recover();
                break;
            case AiState.Stun:
                break;
            case AiState.Dead:
                Destroy(gameObject);
                break;
            default:
                break;
        }

        if (_isRecovering)
        {
            _recoveringTimer -= Time.deltaTime;
            if (_recoveringTimer <= 0)  // Change from < to <=
            {
                _isRecovering = false;
                _recoveringTimer = RecoveringTimerReset;
                AiState = AiState.Pursuit;
            }
        }
        
    }

    void Pursuit()
    {
        /*
        _agent.isStopped = false;
        _agent.SetDestination(_target.position);
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            print("Here");
            AiState = AiState.Attack;
        }
        */
        _agent.isStopped = false;
        _agent.SetDestination(_target.position);

        float distanceToTarget = Vector3.Distance(transform.position, _target.position);
        if (distanceToTarget <= _agent.stoppingDistance)
        {
            // Ensure the AI is facing the target within the view angle
            Vector3 dirToTarget = (_target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) <= 90 / 2)
            {
                AiState = AiState.Attack;
            }
            else
            {
                // If the target is within stopping distance but not in the view angle,
                // you might want to handle this case, possibly by staying in Pursuit state.
            }
        }
    }
    public void TurnOffColliderHitbox()
    {
        _hitBox.GetComponent<Collider>().enabled = false;
    }
    public void TurnOnColliderHitbox()
    {
        _hitBox.GetComponent <Collider>().enabled = true;
    }
    public void Attack()
    {
        TurnOnColliderHitbox();
        _hitBox.SetDealDamage(true);
        
        //_isRecovering = true;  // Set recovering immediately when attacking
    }
    public void StopAttack()
    {
        _hitBox.SetDealDamage(false);
        //_animator.SetBool("Attack", false);
        _canAttack = false;
        TurnOffColliderHitbox();
        AiState = AiState.Recover;
    }

    void Recover()
    {
        _dealDamage = false;
        _isRecovering = true;
        _agent.isStopped = true;  // Stop the agent during recovery
    }

   
    public void PlayFootsteps()
    {
        _source_footsteps.Play();
    }

    public void StopFootsteps()
    {
        _source_footsteps.Stop();
    }
}
