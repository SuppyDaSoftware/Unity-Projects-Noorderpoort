using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputMovement : MonoBehaviour
{
    //Components script
    CarMovementController CarMovement;

    void Awake()
    {
        CarMovement = GetComponent<CarMovementController>();
    }

    void Update()
    {
        Vector3 input = Vector3.zero;

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        CarMovement.SetInput(input);
    }
}
