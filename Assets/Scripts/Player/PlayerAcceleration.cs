using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAcceleration : MonoBehaviour, IAcceleration
{
    [Header("Player")]
    [SerializeField] private PlayerInputCustom _inputs;
    [SerializeField] private float _accelerationSpeed = 3f;
    //[SerializeField] private Rigidbody2D rb;

    private void FixedUpdate()
    {
        if (_inputs.accelerate != 0)
        {
            Accelerate(_inputs.accelerate);
            Debug.Log(_inputs.accelerate);
        }
        // else
        // {
        //     rb.velocity = Vector2.zero;
        // }
    }

    public void Accelerate(float direction)
    {
        //rb.AddForce(transform.up * direction * accelerationSpeed);
        // Vector3 movement = transform.up * direction * accelerationSpeed * Time.fixedDeltaTime;
        // transform.Translate(movement);


        Vector3 movement = transform.up * direction * _accelerationSpeed * Time.fixedDeltaTime;
        transform.position += movement;

    }
}
