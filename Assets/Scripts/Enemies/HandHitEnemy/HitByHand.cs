using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HitByHand : MonoBehaviour
{
    private Animator animator;
    private FollowPlayer followPlayer;
    private bool isAttacked;
    private float time = 2f;
    private WaitForSeconds waitMachine;
    private DamageController damageController;

    public static event Action HitterMadeHit;

    void Start()
    {
        waitMachine = new WaitForSeconds(time);
        damageController = GetComponent<DamageController>();
        animator = GetComponent<Animator>();
        followPlayer = GetComponent<FollowPlayer>();
    }

    void Update()
    {
        if (damageController.isAlive) HitPlayer();
    }

    private void HitPlayer()
    {
        if (followPlayer.isClose)
        {
            if (!isAttacked)
            {
                StartCoroutine(AttackDelay());
                animator.SetTrigger("ZoneAttack_trig");
                HitterMadeHit?.Invoke();
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
