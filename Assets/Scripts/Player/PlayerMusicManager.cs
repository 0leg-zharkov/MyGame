using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private float volumeMultiplier = 1.0f;
    private AudioSource playerSounds;

    public AudioClip playerShoot;
    public AudioClip playerHitted;
    public AudioClip playerGetHp;

    private void Start()
    {
        playerSounds = GetComponent<AudioSource>();

        RaycastShoot.PlayerShootMade += PlayRifleSound;
        PlayerDamageController.PlayerGetDamage += PlayGetHit;
        PlayerDamageController.PlayerGetHp += PlayGetHp;
    }

    private void OnDisable()
    {
        RaycastShoot.PlayerShootMade -= PlayRifleSound;
        PlayerDamageController.PlayerGetDamage -= PlayGetHit;
        PlayerDamageController.PlayerGetHp -= PlayGetHp;
    }

    private void PlayRifleSound()
    {
        playerSounds.PlayOneShot(playerShoot, volumeMultiplier);
    }

    private void PlayGetHit()
    {
        playerSounds.PlayOneShot(playerHitted, volumeMultiplier);
    }

    private void PlayGetHp()
    {
        playerSounds.PlayOneShot(playerGetHp, volumeMultiplier);
    }
}
