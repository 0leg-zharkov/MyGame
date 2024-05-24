using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int currentHealth = 3;
    public bool isAlive;
    private Animator animator;

    public static event Action LossEnemyHp;

    private void Start()
    {
        isAlive = true;
        animator = GetComponent<Animator>();
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            if (isAlive) StartCoroutine(Die());
            isAlive = false;
        }
    }

    IEnumerator Die()
    {
        LossEnemyHp?.Invoke();
        animator.SetTrigger("Die_trig");
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
