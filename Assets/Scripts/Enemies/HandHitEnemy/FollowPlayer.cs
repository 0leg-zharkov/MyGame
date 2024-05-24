using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;
    public bool isSpotted = false;
    public bool isClose = false;
    public float speed = 7f;
    public float distance = 15f;

    private bool isStay = false;
    private Animator animator;
    private DamageController damageController;
    private float hitDistance = 2f;

    private void Start()
    {
        playerTransform = GameObject.Find("Capsule").transform;
        damageController = GetComponent<DamageController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (damageController.isAlive)
        {
            CheckDistance();
            if (isSpotted)
            {
                if (!isStay) Follow();
            }
        }
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < distance)
        {
            transform.LookAt(playerTransform);
            isSpotted = true;
            animator.SetBool("IsWalkingZone", true);
        }
        else
        {
            animator.SetBool("IsWalkingZone", false);
        }
        if (Vector3.Distance(playerTransform.localPosition, transform.position) < hitDistance)
        {
            animator.SetBool("IsAttackZone", true);
            isClose = true;
            isStay = true;
        }
        else
        {
            animator.SetBool("IsAttackZone", false);
            isStay = false;
            isClose = false;
        }
    }

    private void Follow()
    {
        Vector3 direction = (playerTransform.localPosition - transform.localPosition).normalized;
        //gameObject.GetComponent<Rigidbody>().MovePosition((gameObject.GetComponent<Rigidbody>().position + direction) * Time.deltaTime);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
