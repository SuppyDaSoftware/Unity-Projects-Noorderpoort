using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    public float speedForce;
    [SerializeField]
    public float brakeForce;
    
    [SerializeField]
    private Rigidbody2D rb;
    
    [SerializeField]
    private Vector3 turningRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move car forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * speedForce * Time.deltaTime);
        }
        // Stop the car using a break and go backward
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.up * speedForce * Time.deltaTime);
        }

        //Turn vehichle
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-turningRotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(turningRotation * Time.deltaTime);
        }

    }
}
