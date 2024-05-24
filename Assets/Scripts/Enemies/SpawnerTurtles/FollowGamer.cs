using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGamer : MonoBehaviour
{
    private Transform playerTransform;
    public bool isSpotted = false;
    public bool isClose = false;
    public float speed = 7f;
    public float distance = 15f;

    private Animator animator;

    private float hitDistance = 2f;

    private void Start()
    {
        playerTransform = GameObject.Find("Capsule").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckDistance();
        if (isSpotted)
        {
            Follow();
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
        else animator.SetBool("IsWalkingZone", false);
        if (Vector3.Distance(playerTransform.position, transform.position) < hitDistance)
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }
    }

    private void Follow()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
