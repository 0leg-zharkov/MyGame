using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurtle : MonoBehaviour
{
    public GameObject turtlePrefab;

    private float time = 10f;

    void Start()
    {
        InvokeRepeating("Spawn", 0, time);
    }

    void Update()
    {

    }

    private void Spawn()
    {
        turtlePrefab.transform.position = transform.position;
        turtlePrefab.SetActive(true);
        Instantiate(turtlePrefab);
    }
}

