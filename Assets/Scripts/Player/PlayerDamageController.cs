using System.Collections;
using System;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    public int currentHealth = 100;
    public static event Action PlayerGetDamage;
    public static event Action PlayerGetHp;

    public void Damage(int damageAmount)
    {
        PlayerGetDamage?.Invoke();

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Debug.Log("Здоровье меньше 0");
            Debug.Log($"хп = {currentHealth}");
        }
    }

    public void Heal(int healAmount)
    {
        PlayerGetHp?.Invoke();

        currentHealth += healAmount;
    }
}
