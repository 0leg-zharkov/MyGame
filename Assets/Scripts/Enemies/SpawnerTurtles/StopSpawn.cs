using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSpawn : MonoBehaviour
{
    public GameObject firstSpawner;
    public GameObject secondSpawner;
    private bool isDestroyed;

    void Start()
    {
        isDestroyed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isDestroyed)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isDestroyed = true;
                firstSpawner.SetActive(false);
                secondSpawner.SetActive(false);
                Destroy(firstSpawner);
                Destroy(secondSpawner);
            }
        }
        if (collision.gameObject.CompareTag("Hitter"))
        {
            Destroy(collision.gameObject);
        }
    }
}
