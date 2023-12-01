using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputCustom : MonoBehaviour, IFireInput, IAccelerationInput, IRotationInput
{
    //[Header("Player Input Values")]

    public bool fire { get; private set; }

    public float accelerate;

    public float rotation;

    public void OnFire(InputValue value)
    {
        FireInput(value.isPressed);
    }

    public void OnAcceleration(InputValue value)
    {
        AccelerateInput(value.Get<float>());
    }

    public void OnRotation(InputValue value)
    {
        RotateInput(value.Get<float>());
    }

    public void FireInput(bool newFireState)
    {
        fire = newFireState;
    }

    public void AccelerateInput(float newAcceleration)
    {
        accelerate = newAcceleration;
    }

    public void RotateInput(float newRotation)
    {
        rotation = newRotation;
    }
}