using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFireTrap : MonoBehaviour
{
    public GameObject activator;
    private bool isActive;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isActive = true;
                activator.SetActive(true);
            }
        }
    }
}
