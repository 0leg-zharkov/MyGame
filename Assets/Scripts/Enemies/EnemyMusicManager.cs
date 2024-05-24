using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMusicManager : MonoBehaviour
{
    [SerializeField] private float volumeMultiplier = 0.8f;

    private AudioSource enemySounds;

    public AudioClip enemyAttack;
    public AudioClip enemyDeth;

    private void Start()
    {
        enemySounds = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        switch (gameObject.tag)
        {
            case "Sniper":
                EnemyShoot.SniperMadeShoot += PlayAttackSound;
                DamageController.LossEnemyHp += PlayDethSound;
                break;
            case "Hitter":
                HitByHand.HitterMadeHit += PlayAttackSound;
                DamageController.LossEnemyHp += PlayDethSound;
                break;
            default:
                break;
        }
        

    }

    private void OnDisable()
    {
        switch (gameObject.tag)
        {
            case "Sniper":
                EnemyShoot.SniperMadeShoot -= PlayAttackSound;
                DamageController.LossEnemyHp -= PlayDethSound;
                break;
            case "Hitter":
                HitByHand.HitterMadeHit -= PlayAttackSound;
                DamageController.LossEnemyHp -= PlayDethSound;
                break;
            default:
                break;
        }
        
    }

    private void PlayAttackSound()
    {
        enemySounds.PlayOneShot(enemyAttack, volumeMultiplier);
    }

    private void PlayDethSound()
    {
        enemySounds.PlayOneShot(enemyDeth, volumeMultiplier);
    }
}
