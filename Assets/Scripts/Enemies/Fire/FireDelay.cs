using System.Collections;
using System;
using UnityEngine;

public class FireDelay : MonoBehaviour
{
    public ParticleSystem firstFire;
    public ParticleSystem secondFire;
    public ParticleSystem thirdFire;
    
    private bool isFirstFire;
    private bool isSecondFire;
    private bool isThirdFire;

    private bool isTurnOnFirst;
    private bool isTurnOnSecond;
    private bool isTurnOnThird;

    private bool isTurnOffFirst;
    private bool isTurnOffSecond;
    private bool isTurnOffThird;

    public float firstWorkTime = 3f;
    public float secondWorkTime = 2f;
    public float thirdWorkTime = 4f;

    public float firstDelayTime = 5.5f;
    public float secondDelayTime = 4f;
    public float thirdDelayTime = 6f;
    
    private WaitForSeconds firstWorkWait;
    private WaitForSeconds secondWorkWait;
    private WaitForSeconds thirdWorkWait;
    
    private WaitForSeconds firstDelayWait;
    private WaitForSeconds secondDelayWait;
    private WaitForSeconds thirdDelayWait;

    public static event Action FireIsBegan;

    void Start()
    {
        isFirstFire = true;
        firstWorkWait = new WaitForSeconds(firstWorkTime);
        secondWorkWait = new WaitForSeconds(secondWorkTime);
        thirdWorkWait = new WaitForSeconds(thirdWorkTime);
        firstDelayWait = new WaitForSeconds(firstDelayTime);
        secondDelayWait = new WaitForSeconds(secondDelayTime);
        thirdDelayWait = new WaitForSeconds(thirdDelayTime);
    }

    void Update()
    {
        //первый огонь
        if (isFirstFire)
        {
            if (!isTurnOnFirst)
            {
                FireIsBegan?.Invoke();
                StartCoroutine(TurnOnFirstFire());
            }
        }
        else
        {
            if (!isTurnOffFirst)
                StartCoroutine(DelayFirstFire());
        }
        //второй огонь
        if (isSecondFire)
        {
            if (!isTurnOnSecond)
            {
                FireIsBegan?.Invoke();
                StartCoroutine(TurnOnSecondFire());
            }
        }
        else
        {
            if (!isTurnOffSecond)
                StartCoroutine(DelaySecondFire());
        }
        //третий огонь
        if (isThirdFire)
        {
            if (!isTurnOnThird)
            {
                FireIsBegan?.Invoke();
                StartCoroutine(TurnOnThirdFire());
            }
        }
        else
        {
            if (!isTurnOffThird)
                StartCoroutine(DelayThirdFire());
        }
    }

    private IEnumerator TurnOnFirstFire()
    {
        isTurnOnFirst = true;
        yield return firstWorkWait;
        isTurnOnFirst = false;
        firstFire.Stop();
        isFirstFire = false;
    }

    private IEnumerator DelayFirstFire()
    {
        isTurnOffFirst = true;
        yield return firstDelayWait;
        isTurnOffFirst = false;
        firstFire.Play();
        isFirstFire = true;
    }

    private IEnumerator TurnOnSecondFire()
    {
        isTurnOnSecond = true;
        yield return secondWorkWait;
        isTurnOnSecond = false;
        secondFire.Stop();
        isSecondFire = false;
    }

    private IEnumerator DelaySecondFire()
    {
        isTurnOffSecond = true;
        yield return secondDelayWait;
        isTurnOffSecond = false;
        secondFire.Play();
        isSecondFire = true;
    }

    private IEnumerator TurnOnThirdFire()
    {
        isTurnOnThird = true;
        yield return thirdWorkWait;
        isTurnOnThird = false;
        thirdFire.Stop();
        isThirdFire = false;
    }

    private IEnumerator DelayThirdFire()
    {
        isTurnOffThird = true;
        yield return thirdDelayWait;
        isTurnOffThird = false;
        thirdFire.Play();
        isThirdFire = true;
    }
}
