using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBullet : MonoBehaviour
{
    public float speed = 4f;

    private WaitForSeconds lifeTime; 
    private GameObject player;

    private void Start()
    {
        lifeTime = new WaitForSeconds(5f);

        player = GameObject.Find("Capsule");
    }

    void Update()
    {
        Vector3 direction = (player.transform.localPosition - transform.localPosition).normalized;

        transform.Translate(direction * speed * Time.deltaTime);

        StartCoroutine(DestroyDelay());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Black Sniper"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                DamageManager.SetEnemyDamage(gameObject);
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyDelay()
    {
        yield return lifeTime;
        Destroy(gameObject);
    }
}
