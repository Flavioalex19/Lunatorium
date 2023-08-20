using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{

    Animator _enemyAnimator;

    AI _ai;

    // Start is called before the first frame update
    void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
        _ai = GetComponent<AI>();
    }

    // Update is called once per frame
    void Update()
    {
        //_enemyAnimator.SetFloat("Speed", _ai._agent.isStopped);
        _enemyAnimator.SetBool("isMoving", !_ai._agent.isStopped);
        _enemyAnimator.SetBool("Attack", _ai._canAttack);
    }
}
