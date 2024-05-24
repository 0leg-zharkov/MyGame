using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 4f;

    private float flyTime = 10f;
    private WaitForSeconds waitMachine;


    private void Start()
    {
        waitMachine = new WaitForSeconds(flyTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        StartCoroutine(DestroyUsedBullet());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Sniper"))
        {
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.CompareTag("Player"))
            {
                DamageManager.SetEnemyDamage(gameObject);
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyUsedBullet()
    {
        yield return waitMachine;
        Destroy(gameObject);
    }
}
