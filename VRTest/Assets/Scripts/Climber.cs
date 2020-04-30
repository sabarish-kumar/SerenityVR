using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    public float gravity = 45.0f;//9.81f;
    public float sensitivity = 45.0f;//9.81f;

    private Hand currentHand = null;
    private CharacterController controller = null;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

    }

    private void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        Vector3 movement = Vector3.zero;

        if (currentHand)
            movement += currentHand.Delta * sensitivity;

        if (movement == Vector3.zero)
            movement.y -= gravity * Time.deltaTime;

        controller.Move(movement * Time.deltaTime);
    }

    public void SetHand(Hand hand)
    {
        if (currentHand)
            currentHand.ReleasePoint();

        currentHand = hand;
    }

    public void ClearHand()
    {
        currentHand = null;
    }
}
