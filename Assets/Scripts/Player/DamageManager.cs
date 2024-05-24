using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager instance = null;
    private GameObject player;
    private static PlayerDamageController damageGetter;

    private static int lowDamage = 1; // персонажи враги
    private static int middleDamage = 2; // огонь/треугольник
    private static int fullDamage = 100;
    private static int healthDamage = 3;

    private void Start()
    {
        if (instance == null) instance = this;
        else if (instance == this) Destroy(gameObject);
        InitializeManager();
    }

    private void InitializeManager()
    {
        player = GameObject.Find("Capsule");
        damageGetter = player.GetComponent<PlayerDamageController>();
    }

    public static void SetEnemyDamage(GameObject enemy)
    {
        Debug.Log($"{instance == null}");
        if (enemy.Equals(null)) Debug.Log("ЭНЕМИ = НОЛЬ");
        if (enemy.CompareTag("Hitter") || enemy.CompareTag("Bullet"))
        {
            damageGetter.Damage(lowDamage);
        }
        else if (enemy.CompareTag("Fire") || enemy.CompareTag("Triangle"))
        {
            damageGetter.Damage(middleDamage);
            Debug.Log("ЭНЕМИ = КОНУС");
        }
        else if (enemy.CompareTag("Health"))
        {
            damageGetter.Heal(healthDamage);
        }
        else if (enemy.CompareTag("Death Plane"))
        {
            damageGetter.Damage(fullDamage);
        }
    }

    public static int GetHp()
    {
        return damageGetter.currentHealth;
    }

    public static bool IsPlayerAlive()
    {
        return true ? damageGetter.currentHealth > 0 : false;
    }
}
