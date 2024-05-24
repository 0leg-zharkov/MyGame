using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHit : MonoBehaviour
{
    private float time = 2f;
    private bool isAttacked;
    private Animator animator;
    private FollowGamer followPlayer;
    private WaitForSeconds waitMachine;
    

    void Start()
    {
        waitMachine = new WaitForSeconds(time);
        animator = GetComponent<Animator>();
        followPlayer = GetComponent<FollowGamer>();
    }

    void Update()
    {
        HitPlayer();
    }

    private void HitPlayer()
    {
        if (followPlayer.isClose)
        {
            if (!isAttacked)
            {
                StartCoroutine(AttackDelay());
                animator.SetTrigger("ZoneAttack_trig");
                DamageManager.SetEnemyDamage(gameObject);
            }
        }
    }

    private IEnumerator AttackDelay()
    {
        isAttacked = true;
        yield return waitMachine;
        isAttacked = false;
    }
}
