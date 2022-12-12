using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Coins = 0;
    [SerializeField]private float speed = 3f;
    [SerializeField] private float turnSpeed = 15f;
    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }

    // Cada vez que haya una colisión entre el Player y un Trigger (en este caso la moneda)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Coin"))
        {
            Destroy(other.gameObject);
            Coins += 1;
        }
    }
}
