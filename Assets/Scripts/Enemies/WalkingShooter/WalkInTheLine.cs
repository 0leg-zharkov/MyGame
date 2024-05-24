using UnityEngine;

public class WalkInTheLine : MonoBehaviour
{
    public GameObject player;
    public float angleSpeed = 180f;
    public float speed = 5;

    private EnemyShoot enemyShoot;


    void Start()
    {
        enemyShoot = GetComponent<EnemyShoot>();

        InvokeRepeating("RotatePlayer", 0f, 2f);
    }

    void Update()
    {
        if (!enemyShoot.isShootArea)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //transform.LookAt(player.transform);
        }
        //else
        //{
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}
    }

    private void RotatePlayer()
    {
        transform.Rotate(Vector3.up, angleSpeed);
    }
}
