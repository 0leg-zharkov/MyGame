using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillInTheMoment : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) DamageManager.SetEnemyDamage(gameObject);
    }
}
