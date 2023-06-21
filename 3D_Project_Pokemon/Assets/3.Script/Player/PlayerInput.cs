using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float Posx;
    private float Posz;
    private void Update()
    {
        Posx = Input.GetAxis("Horizontal");
        Posz = Input.GetAxis("Vertical");
    }
}
