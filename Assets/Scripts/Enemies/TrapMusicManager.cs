using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMusicManager : MonoBehaviour
{
    [SerializeField] private float volumeMultiplier = 0.8f;

    private AudioSource trapSounds;

    public AudioClip trapAttack;

    private void Start()
    {
        trapSounds = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        switch (gameObject.tag)
        {
            case "Torus":
                TorusStrike.QueueIsFired += PlayAttackSound;
                break;
            case "Fire":
                FireDelay.FireIsBegan += PlayAttackSound;
                break;
            default:
                break;
        }


    }

    private void OnDisable()
    {
        switch (gameObject.tag)
        {
            case "Torus":
                TorusStrike.QueueIsFired -= PlayAttackSound;
                break;
            case "Fire":
                FireDelay.FireIsBegan -= PlayAttackSound;
                break;
            default:
                break;
        }
    }

    private void PlayAttackSound()
    {
        trapSounds.PlayOneShot(trapAttack, volumeMultiplier);
    }
}
