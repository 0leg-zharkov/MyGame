using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    private float liveTime = 2f;
    private WaitForSeconds waiter;

    void Start()
    {
        waiter = new WaitForSeconds(liveTime);
        StartCoroutine(DestroyTime());
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private IEnumerator DestroyTime()
    {
        yield return waiter;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DamageManager.SetEnemyDamage(gameObject);
        }
        Destroy(gameObject);
    }
}
