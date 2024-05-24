using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10.0f;
    private float translation;
    private float straffe;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DamageManager.IsPlayerAlive())
        {
            //translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            //straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            //transform.Translate(straffe, 0, translation);
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 vper = gameObject.transform.forward * verticalInput * speed * Time.fixedDeltaTime;
            Vector3 vstor = gameObject.transform.right * horizontalInput * speed * Time.fixedDeltaTime;

            Vector3 movement = vper + vstor;

            playerRb.MovePosition(playerRb.position + movement /* Time.fixedDeltaTime*/);
            //playerRb.AddForce(movement, ForceMode.Impulse);

        }
    }
}
