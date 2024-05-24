using System.Collections;
using System;
using UnityEngine;

public class TorusStrike : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float delayTime = 0.2f;
    private WaitForSeconds delayBeforeBullet;
    private int amountOfBullets = 10;
    [SerializeField] private float queueTime;
    [SerializeField] Vector3 zSdvig = new Vector3(0, 0.2f, 0.2f);

    public static event Action QueueIsFired;

    // Start is called before the first frame update
    void Start()
    {
        delayBeforeBullet = new WaitForSeconds(delayTime);
        InvokeRepeating("FireAQueue", 0f, queueTime);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private IEnumerator DelayFire()
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            bulletPrefab.transform.position = gameObject.transform.position;
            Vector3 pos = bulletPrefab.transform.position + zSdvig;
            bulletPrefab.transform.position = pos;
            Instantiate(bulletPrefab);
            yield return delayBeforeBullet;
        }
    }
    private void FireAQueue()
    {
        if (gameObject.activeInHierarchy)
        {
            QueueIsFired?.Invoke();
            StartCoroutine(DelayFire());
        }
    }
}
