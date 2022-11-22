using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputMovement : MonoBehaviour
{
    //Components script
    CarMovement CarMovement;

    void Awake()
    {
      CarMovement = GetComponent<CarMovement>();   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Vector2.zero;

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        CarMovement.SetInput(input);
    }
}
