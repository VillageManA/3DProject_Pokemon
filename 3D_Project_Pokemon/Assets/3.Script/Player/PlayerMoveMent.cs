using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    [SerializeField] public float walkSpeed = 5f;
    [SerializeField] public float runSpeed = 10f;
    private float rotationSpeed = 5f;

    public void MoveTo(Vector3 direction, float speed)
    {
        if (direction.magnitude > 0)
        {
            Vector3 moveDirection = direction.normalized * speed * Time.deltaTime;
            transform.position += moveDirection;
        }
    }
    public void RotateCharacter(float rotationInput)
    {
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }
}
