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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        CarMovement.SetInput(input);
    }
}
