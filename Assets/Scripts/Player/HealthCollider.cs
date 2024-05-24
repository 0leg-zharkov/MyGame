using UnityEngine;

public class HealthCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        DamageManager.SetEnemyDamage(gameObject);
        Destroy(gameObject);
        Debug.Log(collision.gameObject);
    }
}
