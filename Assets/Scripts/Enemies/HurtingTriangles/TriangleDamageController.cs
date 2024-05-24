using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleDamageController : MonoBehaviour
{
    private bool isExited = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isExited)
            {
                isExited = false;
                DamageManager.SetEnemyDamage(gameObject);
            }   
        }
    }


    private void OnCollisionExit(Collision collision) => isExited = true;
}


