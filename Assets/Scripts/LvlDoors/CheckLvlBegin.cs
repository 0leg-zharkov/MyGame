using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLvlBegin : MonoBehaviour
{
    public bool isInLvl;

    void Start()
    {
        isInLvl = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isInLvl = true;
    }
}
