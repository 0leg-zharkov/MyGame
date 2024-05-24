using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FireHit : MonoBehaviour
{
    private bool isHitted;
    private float time = 1f;
    private WaitForSeconds waitMachine;

    // Start is called before the first frame update
    private void Start()
    {
        waitMachine = new WaitForSeconds(time);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player")) 
        {
            if (!isHitted)
            {
                DamageManager.SetEnemyDamage(gameObject);
                StartCoroutine(DamageDelay());
            } 
        }
    }

    private IEnumerator DamageDelay()
    {
        isHitted = true;
        yield return waitMachine;
        isHitted = false;
    }
}
