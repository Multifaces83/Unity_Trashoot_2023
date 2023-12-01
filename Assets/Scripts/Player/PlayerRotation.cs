using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour, IRotation
{
    [Header("Player")]
    [SerializeField] private PlayerInputCustom _inputs;
    [SerializeField] private float rotationSpeed = 3f;
    //[SerializeField] private Rigidbody2D rb;

    private void FixedUpdate()
    {
        if (_inputs.rotation != 0)
        {
            Rotate(_inputs.rotation);
        }
        Debug.Log("Rotation: " + _inputs.rotation);
    }
    public void Rotate(float direction)
    {
        transform.Rotate(Vector3.forward * direction * rotationSpeed);
    }
}
