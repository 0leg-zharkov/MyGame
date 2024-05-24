using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public int gunDamage = 1;                                            
    public float fireRate = 0.833f * 2f;    
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public float angleSpeed = 7f;
    public Transform gunEnd;
    private Animator animator;
    private DamageController damageController;
    public bool isShootArea;
    private WaitForSeconds waitMachine;
    private bool isFired;

    public static event Action SniperMadeShoot;
    public float distance = 10f;

    void Start()
    {
        waitMachine = new WaitForSeconds(fireRate);
        damageController = GetComponent<DamageController>();
        animator = GetComponent<Animator>();
        isShootArea = false;
    }

    void Update()
    {
        CheckPlayerDistance();

        //if (Time.time > nextFire && isShootArea)
        //{
        //    nextFire = Time.time + fireRate;
        //    if (damageController.isAlive) Shoot();
        //    animator.SetTrigger("Attacked_trig");
        //}

        if (isShootArea && damageController.isAlive)
        {
            transform.LookAt(player.transform);
            Result();
        }
    }

    private void CheckPlayerDistance()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < distance)
        {
            animator.SetTrigger("BattleBegin_trig");
            isShootArea = true;
        }
    }

    private void Shoot()
    {
        SniperMadeShoot?.Invoke();

        animator.SetTrigger("Attack_trig");
        bulletPrefab.transform.localPosition = gunEnd.position;
        bulletPrefab.transform.localRotation = transform.rotation;
        Instantiate(bulletPrefab);
    }

    private IEnumerator Reload()
    {
        isFired = true;
        yield return waitMachine;
        isFired = false;
    }

    private void Result()
    {
        if (!isFired)
        {
            
            Shoot();
            StartCoroutine(Reload());
            animator.SetTrigger("Attacked_trig");
        }
    }
}
