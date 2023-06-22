using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    Vector3 Direction = Vector3.zero;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    public void MoveTo(Vector3 direction)
    {
        gameObject.transform.position += direction * walkSpeed * Time.deltaTime;
    }
    public void RunTo(Vector3 direction)
    {
        gameObject.transform.position += direction * runSpeed * Time.deltaTime;

    }
}
